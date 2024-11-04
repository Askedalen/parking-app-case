# parking-app-case
Interview case

## Oppsett

Systemet består av to deler:
- Et ASP.NET Core API som henter data fra Statens Vegvesen, lagrer det i en egen database og har ett endepunkt for å hente informasjon om parkeringer for et gitt poststed.
- En Angular web app som henter informasjon fra API'et og viser det for brukeren.

### Kjøring
API'et kan kjøres ved å åpne ParkingApi.sln i Visual Studio, velge "Docker Compose" som oppstartsprosjekt og kjøre det. Krever at Docker Desktop kjører på maskinen. Det opprettes to Docker-containere, én med API'et på localhost:5000 og én med database på localhost:1433.

Web-appen kan kjøres ved å navigere til parking-app/ i terminalen og kjøre `ng serve --open`. Da kjøres applikasjonen på localhost:4200, og nettleseren åpnes med denne addressen. Krever Node v22 eller nyere og Angular CLI. 

## Svar på oppgaver
### Del 1
1. Bruker query parameters for filter. Det er en vanlig måte å gjøre filtrering, og alle query parameters er optional. For frontend-appen kan det hende det ville vært mer ryddig å bruke et objekt og hatt det i request body.
2. De ekstra dataene vil ikke påvirkes av endringer i dataene fra Statens Vegvesen, fordi ParkingArea-objektet oppdateres med Update-metoden. 

### Del 2
Q: Hvilke data om brukeraktivitet ville du logget i denne applikasjonen, og hvorfor?

A: Jeg ville logget telemetri for minne/prosessorbruk, requests, exceptions og dependencies. Dette er nyttig informasjon for overvåking av systemets helse og feilsøking. Forbruk og ytelse logges i hovedsak for å oppdage minnelekkasjer eller midlertidige spikes som gjør applikasjonen tregere. Requests logges for å overvåke ytelse og eventuelle feilmeldinger fra brukerens perspektiv. Exceptions logges for å oppdage hvor i koden noe feiler. Dependencies måles for å oppdage om tilkobling til eksterne ressurser feiler og hvorfor. Hvis det er relevant for salgsavdelingen eller ledelsen, ville jeg også kanskje tatt i bruk et verktøy som Google Analytics for å hente demografisk informasjon om brukerne og hvilke deler av applikasjonen som brukes mest. 

Q: Hvilke tiltak ville du brukt for å overvåke systemstatus, og hvordan kan dette bidra til å sikre god stabilitet og ytelse?

A: For denne applikasjonen ville jeg nok bare brukt Azure Application Insights og satt opp varsling ved 500-feil, mange trege requests og feil ved kall til Statens Vegvesens API. På grunn av applikasjonens enkelhet tror jeg dette ville vært tilstrekkelig. Det kan også være en god idé å inkludere health checks som kalles automatisk ved korte intervaller, og som varsler utviklerne hvis noe ikke fungerer som det skal. Det vil gi umiddelbar varsling om nedetid og manglende kobling til avhengigheter som SQL Server. 

Q: Hvordan kan effektiv state-håndtering bidra til en bedre brukeropplevelse?

A: Effektiv state-håndtering bidrar til bedre ytelse og reduserer sjansen for feil i applikasjonen. State-håndtering kan være komplisert og blir fort rotete i min erfaring. Ved å bruke verktøy som NGRX er det i stor grad mulig å separere state fra komponentene, som kan gjøre det mye lettere å jobbe med, men det innfører også en del kompleksitet og mye boilerplate-kode. I denne applikasjonen er det veldig lite state, så her har jeg beholdt dataene som observables så langt opp i hierarkiet som nødvendig, sender det ned til underkomponentene og lar Angular sin change detection håndtere oppdateringer av grensesnittet. Hvis det blir nødvendig å dele state mellom frittstående komponenter, kan man bruke services som inneholder state i form av Subjects eller BehaviourSubjects. Det er en helt grei løsning hvis det ikke er veldig komplekst, og mye mindre kostbart å implementere enn NGRX.

Q: Hvilke andre integrasjoner kunne vært relevante for løsningen, og hva slags verdi kunne disse tilføre?

A: Hvis det er mulig, kunne det vært nyttig å integrere med løsninger som EasyPark og Apcoa Flow for å hente informasjon om priser og ledige plasser. Jeg er usikker på om dette er noe disse tilbyr. 

Q: Hvordan ville du håndtert oppdatering av mellomlagrede data for å holde informasjonen synkronisert med Statens Vegvesens register?

A: Som det er implementert nå, blir dataene fra Statens Vegvesen kun hentet ved oppstart av tjenesten. Det både øker oppstartstiden, og gjør at dataene aldri oppdateres med mindre tjenesten starter på nytt. I en produksjonsversjon ville jeg nok hentet data med en asynkron bakgrunnsjobb som kjørte f.eks. hver natt. Da vil man unngå at den prosessen blokkerer API'et. Jeg ser ikke for meg at disse dataene oppdateres ofte, så jeg tror det vil være tilstrekkelig å oppdatere én gang i døgnet. Om nødvendig kan det også gjøres f.eks. hver time uten at det har noen stor innvirkning på ytelse, avhengig av tilgjengelig minne/prossessorkraft. 

### Stegvis prosess

1. Sette opp nytt ASP.NET Core API med database i Docker Compose
2. Få tilgang til og teste API for parkeringsregisteret
3. Opprette response-modeller og kalle API'et fra .NET
4. Designe database: Hvilke data trenger brukeren? Normalisering, kompromisser
5. Hente data og lagre i databasen ved oppstart
6. Endepunkt for å hente parkeringer for et poststed
7. Filtermodell
8. Sette opp Angular-prosjekt, installere dependencies
9. Styling og struktur
10. Liste som viser parkeringer for poststed
