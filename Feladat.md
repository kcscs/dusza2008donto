---


---

<h1 id="döntő">Döntő</h1>
<ol start="2009">
<li>február 28.</li>
</ol>
<h1 id="processzor">Processzor</h1>
<p>Az Intal cég új processzort kíván gyártani. A processzor fantázianeve: Intal Pentimum.<br>
A tervek elkészültek, de mielőtt a sorozatgyártásba kezdenének, meg akarnak győződni arról, hogy a Pentimum tervezett utasításkészlete megfelel a felhasználói igényeknek.<br>
A Pentimumot egy olyan alaplapra integrálták, amelynek egy IO-felülete a hozzá csatlakoztatott $400 byte kapacitású memória, egy outputja pedig egy képernyő illesztési felület. A képernyő felbontása 10x10 karakter, a képernyő csak szöveges információ megjelenítésére alkalmas.<br>
A csapat feladata, hogy szoftveres támogatást nyújtson</p>
<h1 id="feladatok">Feladatok</h1>
<h2 id="fordítóprogram-készítése">fordítóprogram készítése:</h2>
<p>A program bemenete egy szövegfile, amely a Pentimum utasításkészletén implementált programot ír le assembly4nyelven.<br>
A fordítóprogram ezt az assembly programot fordítja le gépi kódra a processzor megadott utasításkészletének megfelelően.<br>
A program kimenete a gépi kódot tartalmazó szövegfájl.</p>
<ul>
<li>emulátor készítése:<br>
Ennek a programnak a segítségével szoftveresen emulálható a processzor működése. Az emulátor bemenete egy byte-kódú (gépi kódú) program. Az emulátor PC-n futtatható, és a PC képernyőjén jeleníti meg a memória és a processzor állapotát.</li>
<li>mintaprogram készítése:<br>
A cég mintaprogramot is kíván adni a processzor dokumentációja mellé, ezért egy kitűzött feladatot is meg kell oldani a processzor utasításkészletével.<br>
A mintaprogram egy olyan assembly kód, amelyet a processzor utasításkészletével kell megírni, a fordítóprogrammal le kell fordítani, majd az így kapott gépi kódú programot kell az emulátoron futtatni.</li>
</ul>
<h2 id="a-pentimum-és-architektúrája">A Pentimum és architektúrája</h2>
<p>A memória mérete $400 byte. Az első $64 byte a 10x10 karaktert megjelenítő képernyő számára fenntartott memória. Minden egyes byte egy cellát jelöl a képernyőn, az ott lévő értékek pedig – a megjelenítés szempontjából – ASCII kódolásúak. A memóriahelyek és a 10x10-es képernyő kapcsolata:</p>

