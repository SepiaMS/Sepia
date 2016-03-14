SPECS_PDF = doc_specs.pdf
SPECS_TEX = src/doc_specs.tex

all: doc

doc: $(SPECS_PDF)

$(SPECS_PDF): $(SPECS_TEX)
	latexmk -pdf -pdflatex="pdflatex -interaction=nonstopmode" -use-make $(SPECS_TEX)

clean:
	latexmk -C -f $(wildcard *)

re: clean all

.PHONY: all clean doc $(SPECS_PDF)
