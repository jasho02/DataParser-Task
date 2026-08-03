Zadanie kwalifikacyjne polegające na stworzeniu generycznego parsera danych (CSV/JSON) przesyłanych w formacie Base64 przez endpoint API.

Funkcjonalności
- Obsługa formatu CSV (z automatycznym usuwaniem zbędnych znaków białych).
- Obsługa formatu JSON (zarówno pojedyncze obiekty, jak i tablice).
- Walidacja typów danych i obsługa błędów Base64.
- Dokumentacja API za pomocą Swagger UI.

Technologia
- C# / .NET 10
- ASP.NET Core Minimal APIs
- System.Text.Json

Jak uruchomić lokalnie

1. Upewnij się, że masz zainstalowane [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0).
2. Sklonuj repozytorium:
   ```bash
   git clone https://github.com/jasho02/DataParser-Task.git
3. Przejdź do folderu projektu:
    cd DataParser
4. Uruchom aplikacjeL
    dotnet run
5. Po uruchomieniu otwórz przeglądarke i przejdź pod adres podany w terminalu + /swagger:
    np. http://localhost:5000/swagger
