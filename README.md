# Kino
## Avtorja
* `Domen Antlej` - 63160055
* `Jaka Rizmal` - 63170254
## Opis delovanja
V okviru projekta bova ustvarila spletno aplikacijo, ki omogoča ogled sporeda in rezervacijo kart za kinematograf.  
Na spletni strani lahko admin ureja in dodaja filme in predvajanja. V aplikaciji pa si lahko uporabnik rezervira sedeže.

## Naloge avtorjev
* Domen Antlej - Zasnova podatkovne baze in vnos začetnih podatkov, razvoj spletne strani
* Jaka Rizmal - Izdelava ogrodja projekta, izdelava API, Swagger dokumentacije in mobilne aplikacije, deploy strani in podatkovne baze na Azure

## Dostop do spletne strani
Spletna stran in podatkovna baza sta gostovani na `Microsoft Azure`. Spletna stran je dosegljiva na spodnji povezavi.  
https://is-kino.azurewebsites.net/
### API Dokumentacija
API dokumentacija, izdelana s pomočjo `Swagger UI`.  
https://is-kino.azurewebsites.net/swagger/index.html
### Račun administratorja
Uporabniško ime: `admin@kino.si`  
Geslo: `Geslogeslo1!`
## Zaslonske slike aplikacije
<img width="300" src="https://i.ibb.co/GWmMDsJ/138209959-422024085898505-4998244851535061358-n.jpg" alt="138209959-422024085898505-4998244851535061358-n" border="0">
Ob zagonu se prikaže seznam filmov. <br>
<img width="300" src="https://i.ibb.co/rvggZhj/138642986-859425624858350-4499700615698124556-n.jpg" alt="138642986-859425624858350-4499700615698124556-n" border="0">
Ob izboru filma se prikažejo predvajanja tega filma.
<br>
<img width="300" src="https://i.ibb.co/bHvXH2L/138042262-406687407445294-2199307498776672607-n.jpg" alt="138042262-406687407445294-2199307498776672607-n" border="0">
Ob izboru predvajanja se prikažejo zasedeni sedeži. 
<br>
<img width="300" src="https://i.ibb.co/cwJ1Qbs/138460058-228091648789051-1954848614150605506-n.jpg" alt="138460058-228091648789051-1954848614150605506-n" border="0">
Ob kliku na prazne sedeže se ti obarvajo.
<br>
<img width="300" src="https://i.ibb.co/g3fg313/138783804-320046176011997-4929465510879045417-n.jpg" alt="138783804-320046176011997-4929465510879045417-n" border="0">
Ob kliku na gumb "rezerviraj", se izbrani sedeži zapišejo v bazo podatkov.

## Diagram baze podatkov
Poleg teh entitet so v bazi podatkov še entitete od Microsoft Identity.
<img src="https://i.ibb.co/Nx6wFxb/baza.png" alt="baza" border="0">
<br>
Glavna entiteta je `Movie`, ki je preko povezovalne tabele povezan na `Genres`.  
Na `Movie` so povezane še osebe `People` preko povezovalnih tabel. Oseba je lahko igralec ali pa režiser.  
Aplikacija rezervira sedeže v tabeli `SeatShowing`, ki je vezana na predvajane `Showing`.
Vsako predvajanje je vezano na dvorano `Room`, ki pa ima sedeže `Seat`.
