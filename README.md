# ShipApplication

## Текст задания:

Класс Ship имеет поле Name

Класс Product имеет поле Name

Класс Voyage имеет поля:
- Ship
- Product
- Weight погруженный вес
- Arrival дата/время подхода судна
- Sailed дата/время ухода судна

Нужно сделать два приложения на Core (фронт любой):
- Приложение 1 на Core (вспомогательное) позволяет создавать / редактировать (CRUD) объекты Voyage, Product, Ship в БД и первоначально инициализирует тестовыми данными в БД.
- Приложение 2 на Core (основное приложение) схематично визуализирует в виде графических примитивов (рисует) суда в 3 группы:
1. Первая группа содержит суда, которые подходят в течение суток (подписи: Ship, Arrival)
2. Вторая группа содержит суда, находящиеся у причала под погрузкой (подписи: Ship, Product, Weight, Arrival)
3. Третья группа содержит суда, которые ушли в течение суток (подписи: Ship, Product, Weight, Arrival, Sailed)

Приложение 2 должно в реал-тайме отрисовывать суда и подписи после модификации данных в БД.
Приложение 1 модифицирует данные в БД и не взаимодействует с Приложением 2.

## Инструкция к запуску

Представленнно два решения (.sln). Изначально:
1. Запустить файл решения Ships.Api.sln из папки Ships.Api.
2. Восстановить клиентские библиотеки (ПКМ по файлу решения -> Восстановить клиентские библиотеки).
3. Запустить приложение и дождаться отображения контента на стартовой странице (при первом запуске инициализируется БД и заполняется тестовыми данными)

Далее можно переходить к решению ShipDrawer.sln из папки ShipDrawer. Перед запуском так же необходимо восстановить клиентские библиотеки