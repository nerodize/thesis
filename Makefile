SRCDIR = .
OUTDIR = build/main
MAIN = main

LATEXMK = latexmk
LATEXMK_OPTS = -pdf -interaction=nonstopmode -file-line-error -synctex=1

all: $(OUTDIR)/$(MAIN).pdf

$(OUTDIR)/$(MAIN).pdf: $(SRCDIR)/$(MAIN).tex
	@mkdir -p $(OUTDIR)
	$(LATEXMK) $(LATEXMK_OPTS) -output-directory=$(OUTDIR) $(SRCDIR)/$(MAIN).tex

clean:
	$(LATEXMK) -C -output-directory=$(OUTDIR)
	rm -rf $(OUTDIR)

clean-temp:
	$(LATEXMK) -c -output-directory=$(OUTDIR)

.PHONY: all clean clean-temp
