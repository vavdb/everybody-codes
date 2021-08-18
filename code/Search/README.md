# Intro

Simple search implementation.
Uses top-level statements to reduce boilerplate.

## Expectations

Expects source to be in code\Search
Expects data to be in data\

## How to run

Make sure you have the required .net code runtime.

Navigate to code\Search and run:
```sh
dotnet run --name Neude
```

And get:
```none
501 | UTR-CM-501 Neude rijbaan voor Postkantoor | 52.093421 | 5.118278
503 | UTR-CM-503 Neude plein | 52.093448 | 5.118536
504 | UTR-CM-504 Neude / Schoutenstraat | 52.092995 | 5.119088
505 | UTR-CM-505 Neude / Drakenburgstraat / Vinkenurgstraat | 52.092843 | 5.118351
506 | UTR-CM-506 Vinkenburgstraat / Neude | 52.092378 | 5.117902
507 | UTR-CM-507 Vinkenburgstraat richting Neude | 52.092234 | 5.117766
```

Or

```sh
dotnet run --name baan
```

And get:
```none
501 | UTR-CM-501 Neude rijbaan voor Postkantoor | 52.093421 | 5.118278
557 | UTR-CM-557-Stationsplein / Adama v Scheltemabaan | 52.088382 | 5.112054
```