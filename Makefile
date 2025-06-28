SRCDIR = .
OUTDIR = build/main
MAIN = main

LATEXMK = latexmk
LATEXMK_OPTS = -pdf -interaction=nonstopmode -file-line-error -synctex=1

all: $(OUTDIR)/$(MAIN).pdf

$(OUTDIR)/$(MAIN).pdf: $(SRCDIR)/$(MAIN).tex
	@mkdir -p $(OUTDIR)
	# Erster LaTeX-Lauf
	$(LATEXMK) $(LATEXMK_OPTS) -output-directory=$(OUTDIR) $(SRCDIR)/$(MAIN).tex
	# Biber muss nach dem ersten Lauf ausgeführt werden
	biber --input-directory $(OUTDIR) $(MAIN)
	# Zweiter LaTeX-Lauf, um die Literaturverweise einzubauen
	$(LATEXMK) $(LATEXMK_OPTS) -output-directory=$(OUTDIR) $(SRCDIR)/$(MAIN).tex

clean:
	$(LATEXMK) -C -output-directory=$(OUTDIR)
	rm -rf $(OUTDIR)

clean-temp:
	$(LATEXMK) -c -output-directory=$(OUTDIR)

.PHONY: all clean clean-temp
