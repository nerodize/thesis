# pdflatex mit Output Directory
$pdflatex = 'pdflatex -interaction=nonstopmode -synctex=1 -output-directory=build/main %O %S';

# biber mit Input Directory für .bcf Dateien
$biber = 'biber --input-directory=build/main %O %S';
