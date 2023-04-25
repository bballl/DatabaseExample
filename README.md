# DatabaseExampleEFCore
Задачи:
Разработайте приложение, в котором будет подключено два разных источника данных: MSSQLLocalDB и MS Access.

Первый источник данных должен содержать таблицу с полями:
ID
Фамилия
Имя
Отчество
Номер телефона (может быть пустым)
Email.

Второй источник данных содержит таблицу со следующими полями:
ID
Email
Код товара
Наименование товара

Должна быть возможность просматривать все покупки клиента, добавлять новых пользователей, обновлять данные клиентов, а также полностью очищать данные.

В процессе разработки требуется применить Entity Framework Core.