
# CsvParser.ReadCoffeePrices()

Tenk igjennom hva løkka egentlig gjør:

- Les fila linje for linje
- Filtrer ut blanke linjer
- Split linjer (som ikke er blanke) i dato og pris


Kan du skrive dette som et LINQ uttrykk?


# CoffeePriceTimeSeries.MakeMonthlyAverageTimeSeries()

Tenk igjennom hva løkka egentlig gjør:

- Grupper prisene for hver måned
- Beregn gjennomsnittspris for hver måned

Kan dette gjøres via LINQ?

# CoffeePriceTimeSeries.FindNumPriceIncreases()

- Bygg en sekvens av to-og-to elementer fra lista (curr, next) :  list.Zip(list.Skip(1), (curr, next) => ...)
- Tell antall elementer hvor next.Price > curr.Price

# CoffeePriceTimeSeries.FindMissingDays()

- Bygg en sekvens av (curr, next)
- Lag en range av datoene mellom curr og next: curr.Date.AddDays(1).RangeTo(next.Date.AddDays(-1))
  (range vil være tom dersom det ikke mangler datoer)
- Bruk flatmap (SelectMany) for å flate ut lista

# CoffeePriceTimeSeries.FillMissingDays()

- Bygg en sekvens av (curr, next)
- Lag en liste (range) av CoffeePrice for datoene som mangler mellom curr, next (med pris = curr.Price)
  - Legg til currPrice på starten av lista 
- flatmap lista av lister
- Må legge til det siste elementet i den opprinnelige tidsserien på slutten
  (må legges til eksplisitt fordi intervallene vi bygger for datoene som mangler mellom curr
  og next har exclusive end (next er ikke med i intervallet))

