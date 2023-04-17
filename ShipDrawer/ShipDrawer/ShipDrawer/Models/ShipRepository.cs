using Microsoft.AspNetCore.SignalR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System;
using ShipDrawer.Interfaces;

namespace ShipDrawer.Models
{
    public class ShipRepository : IShipRepository
    {
        private readonly IHubContext<SignalServer> _context;
        string connectionString = "";
        public ShipRepository(IConfiguration configuration, IHubContext<SignalServer> context)
        {
            connectionString = configuration["ConnectionStrings:ShipsConnection"];
            _context = context;
        }

        public DrawerModel GetAllVoyages()
        {
            return RegisterSqlDependency();
        }

        private DrawerModel RegisterSqlDependency()
        {
            var result = new DrawerModel();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlDependency.Start(connectionString);

                //string commandText = "select Id, Weight, Arrival, Sailed, ShipId, ProductId from dbo.Voyages";
                string commandText = @"select v.Id, v.Weight, v.Arrival, v.Sailed, dbo.Ships.Name AS ShipName, dbo.Products.Name as ProductName
                                        from dbo.Voyages v
                                        join dbo.Ships on v.ShipId = dbo.Ships.Id
                                        join dbo.Products on v.ProductId = dbo.Products.Id";

                SqlCommand cmd = new SqlCommand(commandText, conn);

                SqlDependency dependency = new SqlDependency(cmd);

                dependency.OnChange += new OnChangeEventHandler(dbChangeNotification);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var voyage = new DrawVoyage
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Weight = Convert.ToSingle(reader["Weight"]),
                        Arrival = Convert.ToDateTime(reader["Arrival"]),
                        Sailed = Convert.ToDateTime(reader["Sailed"]),
                        ShipName = reader["ShipName"].ToString(),
                        ProductName = reader["ProductName"].ToString(),
                    };

                    VoyageDistribution(voyage, result);
                }
            }

            return result;
        }

        private void dbChangeNotification(object sender, SqlNotificationEventArgs e)
        {
            _context.Clients.All.SendAsync("refreshVoyages");

            //SqlDependency dependency = sender as SqlDependency;
            //dependency.OnChange -= dbChangeNotification;

            //RegisterSqlDependency();
        }

        private void VoyageDistribution(DrawVoyage voyage, DrawerModel model)
        {
            var currentDate = DateTime.Now;
            var startDateForSailed = DateTime.Now.AddDays(-1);
            var endArrivalDate = DateTime.Now.AddDays(1);

            if (voyage.Sailed < currentDate && voyage.Sailed > startDateForSailed)
            {
                model.Gone.Add(voyage);
            }
            else if (voyage.Arrival > currentDate && voyage.Arrival < endArrivalDate)
            {
                model.OnTheWay.Add(voyage);
            }
            else if (voyage.Arrival < currentDate && voyage.Sailed > currentDate)
            {
                model.UnderLoading.Add(voyage);
            }
        }
    }
}
