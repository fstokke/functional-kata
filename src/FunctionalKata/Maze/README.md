
# FindAllPaths()

Denne er allerede skrevet i funksjonell stil. OK som den er?


# FindStartPos()

- Kan skrives som en kombinasjon av (flat)map og filter

# FindAllPathsRecursive()

Søker gjennom labyrinten ved å prøve å gå videre i alle mulige retninger ut i fra posisjonen man står på.

"path" parameteret inneholder stien fra startposisjonen fram til nåværende posisjon
(siste element i path er nåværende posisjon)

Bruker AdjacentPositions() til å finne mulige neste skritt på stien. Kandidater er
- Punkter som er "ledige", dvs. de ligger ikke på en "vegg" eller utenfor labyrinten 
- Punkter som ikke ligger på stien man allerede har gått

Bygg opp en liste med mulige "nextPath" og kall funksjonen rekursivt for alle disse.

Funksjonen returnerer en mulig løsning (en liste med en sti) når den blir kalt med en 
  sti hvor det siste punktet i stien er målet (*)

Returner ellers en liste av stier med resultatet av de rekursive kallene. Denne lista vil være tom hvis 
ingen en de rekursive kallene returnerte en mulig løsning.


Hjelpefunksjoner:
- AdjacentPositions(): Denne ligner på noe vi har gjort før i en annen oppgave