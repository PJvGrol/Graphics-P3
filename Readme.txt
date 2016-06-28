Joris van Gool  4270126
Paul van Grol   5528909

Wat we gedaan hebben:
SceneGraph class aangemaakt, bestaande uit mesh, shader, texture en een lijst van SceneGraphs die z'n kinderen zijn om hierarchisch te kunnen orderen.
Er is een SceneGraph class aangemaakt die zelf weer nieuwe SceneGraphs kan bevatten. 
Deze heeft een render functie die er voor zorgt dat de transformatiematrix toegepast word en de kinderen ook gerendered worden
met de juiste getransformeerde matrix. Het phong shading model is geïmplementeerd voor de shader. Hiervoor zijn verscheidenen
vectoren en waardes meegegeven aan de shader. De controls zijn spatie voor omhoog, shift voor naar beneden, W voor naar voren, S
voor naar achter, AD voor links rechts en QE voor draaien naar links en naar rechts.
In game.cs geeft de bool automaticRotation aan of de scene automatisch geroteerd moet worden, default is deze false.
Verder is de waarde van acceleration aan te passen om sneller of minder snel te bewegen bij het gebruik van de controls. We adviseren om deze waarde tussen 1 en 10 te kiezen.

Bonus assignments
Op dit moment is er de mogelijkheid om twee lichten te gebruiken. Deze kunnen aangepast worden in game.cs en zijn opgebouwd als volgt: een 4D Vector voor de positie, waarbij de "w" waarde
altijd 1 is, een 4D Vector voor R,G,B,alpha en een int die de intensiteit aangeeft. In de demo hebben we de twee lichten tegenover elkaar geplaatst zodat je goed ziet dat
de theepot van beide kanten belicht wordt.
  

Materials
  