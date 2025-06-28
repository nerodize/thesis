# Schreibe Hilfsdateien (z. B. .aux) im Quellverzeichnis
$aux_dir = 'build/main';

# Endgültige Ausgaben (PDF etc.) in dieses Verzeichnis
$out_dir = 'build/main';

# pdflatex mit Output Directory
$pdflatex = 'pdflatex -interaction=nonstopmode -synctex=1 -output-directory=build/main %O %S';

# Biber braucht Zugriff auf die .bcf im build-Verzeichnis
$biber = 'biber --input-directory=build/main %O %S';
