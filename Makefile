SPECS_PDF = doc_specs.pdf
SPECS_TEX = src/doc_specs.tex

all: doc

doc: $(SPECS_PDF)

$(SPECS_PDF): $(SPECS_TEX)
	latexmk -use-make -pdf -pdflatex="pdflatex -interaction=nonstopmode" $<
	#       ^         ^
	#       |         Generate PDF right away (instead of DVI)
	#       |
	#       Call make for generating missing files

clean:
	latexmk -C -f $(wildcard *)

re: clean all

.PHONY: all clean doc $(SPECS_PDF)
