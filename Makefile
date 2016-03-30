SPECS_PDF = doc_specs.pdf
SPECS_TEX = src/doc_specs.tex

all: specs

specs: $(SPECS_PDF)

check: specs_check

$(SPECS_PDF): $(SPECS_TEX)
	latexmk -use-make -pdf -pdflatex="pdflatex -interaction=nonstopmode" $<
	@#       ^         ^
	@#       |         Generate PDF right away (instead of DVI)
	@#       |
	@#       Call make for generating missing files

specs_check: $(SPECS_TEX)
	ChkTeX $^

clean:
	latexmk -C -f $(wildcard *)

re: clean all

.PHONY: all clean specs $(SPECS_PDF)
