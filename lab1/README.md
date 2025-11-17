1. Запуск приложения
bash

# Перейди в папку проекта
cd ValeraAPI

# Запусти приложение
dotnet run

2. Тестирование API через Swagger

В Swagger UI ты увидишь:

    GET /api/Valera - получить состояние Валеры

    POST /api/Valera/action - выполнить действие

    POST /api/Valera/reset - сбросить состояние

4. Тестирование через curl (если нужно)
bash

# Получить состояние
curl -X GET https://localhost:7000/api/Valera

# Выполнить действие (например, спать)
curl -X POST https://localhost:7000/api/Valera/action \
  -H "Content-Type: application/json" \
  -d '{"action": "sleep"}'

# Сбросить состояние
curl -X POST https://localhost:7000/api/Valera/reset

5. Запуск тестов (в отдельном терминале)
bash

# Запустить все тесты
dotnet test

# Или конкретно тестовый проект
dotnet test Tests/ValeraAPI.Tests.csproj

6. Если возникли проблемы:
bash

# Восстановить зависимости
dotnet restore

# Построить проект
dotnet build

# Запустить без автоматического открытия браузера
dotnet run --no-launch-profile
