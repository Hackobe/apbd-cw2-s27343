# APBD - Ćwiczenia 2 - Wypożyczalnia sprzętu

## Opis projektu
Projekt przedstawia aplikację konsolową w C#, która obsługuje uczelnianą wypożyczalnię sprzętu.

System umożliwia:
- dodawanie użytkowników do systemu,
- dodawanie sprzętu różnych typów,
- wyświetlanie wszystkich urządzeń i ich statusów,
- wyświetlanie sprzętu dostępnego,
- wypożyczanie sprzętu użytkownikom,
- zwroty sprzętu wraz z naliczaniem kar za opóźnienie,
- oznaczanie sprzętu jako niedostępnego,
- wyświetlanie aktywnych wypożyczeń użytkownika,
- wyświetlanie przeterminowanych wypożyczeń,
- generowanie raportu końcowego.

## Model domenowy
W projekcie zostały użyte następujące klasy domenowe:
- `Equipment` - abstrakcyjna klasa bazowa dla sprzętu,
- `Laptop`, `Projector`, `Camera` - typy sprzętu,
- `User` - abstrakcyjna klasa bazowa dla użytkownika,
- `Student`, `Employee` - typy użytkowników,
- `Rental` - klasa opisująca wypożyczenie.

## Struktura projektu
Projekt został podzielony na kilka folderów:
- `Models` - klasy domenowe,
- `Enums` - typy wyliczeniowe,
- `Services` - logika biznesowa,
- `Program.cs` - scenariusz demonstracyjny działania aplikacji.

## Decyzje projektowe
Kod został podzielony tak, aby oddzielić model domenowy od logiki biznesowej i od warstwy uruchomieniowej.

Dziedziczenie zostało użyte w miejscach, w których wynika ono bezpośrednio z modelu domeny:
- `Laptop`, `Projector`, `Camera` dziedziczą po `Equipment`,
- `Student` i `Employee` dziedziczą po `User`.

Logika biznesowa została przeniesiona do klas serwisowych:
- `EquipmentService` odpowiada za zarządzanie sprzętem,
- `UserService` odpowiada za zarządzanie użytkownikami,
- `RentalService` odpowiada za wypożyczenia, zwroty, limity i kary,
- `ReportService` odpowiada za generowanie raportu.

Dzięki temu `Program.cs` nie zawiera całej logiki aplikacji, a jedynie pokazuje scenariusz demonstracyjny.

## Kohezja, coupling i odpowiedzialności klas
W projekcie starano się zadbać o:
- **kohezję** - każda klasa ma jedno główne zadanie,
- **niski coupling** - modele nie odpowiadają za logikę raportów ani za obsługę przepływu programu,
- **czytelny podział odpowiedzialności** - logika biznesowa znajduje się w serwisach, a dane w klasach modelu.

Przykładowo:
- `Rental` przechowuje dane o wypożyczeniu,
- `RentalService` podejmuje decyzje biznesowe,
- `ReportService` generuje podsumowanie stanu systemu.

## Reguły biznesowe
W projekcie zostały zaimplementowane następujące reguły:
- student może mieć maksymalnie 2 aktywne wypożyczenia,
- pracownik może mieć maksymalnie 5 aktywnych wypożyczeń,
- sprzętu niedostępnego nie można wypożyczyć,
- wypożyczenie jest blokowane po przekroczeniu limitu,
- opóźniony zwrot powoduje naliczenie kary,
- kara za każdy dzień opóźnienia jest zapisana w kodzie w jednym miejscu i może być łatwo zmieniona.

## Scenariusz demonstracyjny
Program pokazuje:
1. dodanie kilku egzemplarzy sprzętu,
2. dodanie kilku użytkowników,
3. poprawne wypożyczenie sprzętu,
4. próbę niepoprawnej operacji,
5. zwrot w terminie,
6. zwrot po terminie z naliczeniem kary,
7. raport końcowy.

## Instrukcja uruchomienia
1. Otwórz projekt w JetBrains Rider lub Visual Studio.
2. Ustaw projekt `APBD-CW2` jako startowy.
3. Uruchom aplikację.
4. Wyniki działania zostaną wyświetlone w konsoli.

## Autor
Jakub Brochocki
