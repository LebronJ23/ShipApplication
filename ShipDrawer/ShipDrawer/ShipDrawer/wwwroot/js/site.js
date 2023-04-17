const draw = SVG().addTo('#svg').size('100%', '100%').attr({ viewBox: '0, 0, 1980, 1024' });
const underLoadingGroup = draw.group();
const onTheWayGroup = draw.group();
const goneGroup = draw.group();

const yOffset = 110;
const percentValue = 1980 * 0.01;

const connection = new signalR.HubConnectionBuilder().withUrl("/signalServer").build();

connection.start();

connection.on("refreshVoyages", function () {
    loadData();
})

drawTable();

loadData();

function loadData() {
    clearSVG();

    $.ajax({
        url: '/Home/GetVoyages',
        method: 'GET',
        success: (result) => {
            $.each(result.underLoading, (k, v) => {
                console.log(k);

                drawShip(underLoadingGroup,
                    [
                        { label: 'ShipName', value: v.shipName },
                        { label: 'Arrival', value: new Date(v.arrival).toLocaleDateString() }
                    ], 10, yOffset + k * 130, 'red');
            })
            $.each(result.onTheWay, (k, v) => {
                console.log(k);

                drawShip(onTheWayGroup,
                    [
                        { label: 'ShipName', value: v.shipName },
                        { label: 'ProductName', value: v.productName },
                        { label: 'Weight', value: v.weight },
                        { label: 'Arrival', value: new Date(v.arrival).toLocaleDateString() }
                    ], percentValue*35, yOffset + k * 130, 'green');
            })
            $.each(result.gone, (k, v) => {
                console.log(k);
                drawShip(goneGroup,
                    [
                        { label: 'ShipName', value: v.shipName },
                        { label: 'ProductName', value: v.productName },
                        { label: 'Weight', value: v.weight },
                        { label: 'ArrivalDate', value: new Date(v.arrival).toLocaleDateString() },
                        { label: 'Sailed', value: new Date(v.sailed).toLocaleDateString() }
                    ], percentValue*68, yOffset + k * 130, 'yellow');
            })
        },
        error: (error) => {
            console.log(error)
        }
    })
}


function drawTable() {
    draw.line(0, 0, 0, '100%').stroke({ width: 1, color: 'green' })
    draw.line('33%', 0, '33%', '100%').stroke({ width: 1, color: 'green' })
    draw.line('66%', 0, '66%', '100%').stroke({ width: 1, color: 'green' })
    draw.line('100%', 0, '100%', '100%').stroke({ width: 1, color: 'green' })
    draw.line(0, 100, '100%', 100).stroke({ width: 1, color: 'green' })
    draw.line(0, 0, '100%', 0).stroke({ width: 1, color: 'green' })
    draw.line(0, '100%', '100%', '100%').stroke({ width: 1, color: 'green' })
    draw.text(function (add) {
        add.tspan('Under Loading')
    }).attr({ x: '16%', y: 50 })
    draw.text(function (add) {
        add.tspan('On the Way')
    }).attr({ x: '49%', y: 50 })
    draw.text(function (add) {
        add.tspan('Gone')
    }).attr({ x: '82%', y: 50 })
}

function clearSVG() {
    underLoadingGroup.clear();
    onTheWayGroup.clear();
    goneGroup.clear();
}

function drawShip(group, props, x, y, col) {
    var shipGroup = group.group();

    shipGroup.polygon([[x, y], [x + percentValue*25, y], [x + percentValue*30, y + 60], [x + percentValue*25, y + 120], [x, y + 120]]).fill('none').stroke({ width: 5, color: col });

    if (props.length) {
        shipGroup.text(function (add) {
            $.each(props, (k, v) => {
                add.tspan(`${v.label}: ${v.value}`).newLine();
            });

        }).attr({ x: x+10, y: y + 20 })
    }

}