SPECS_PDF = doc_specs.pdf
SPECS_TEX = src/doc_specs.tex
SPECS_LINTER = ChkTeX

all: specs

specs: $(SPECS_PDF)

check: specs_check

$(SPECS_PDF): $(SPECS_TEX) specs_check
	@latexmk -use-make -pdf -pdflatex="pdflatex -interaction=nonstopmode" -quiet $<
	@#       ^         ^
	@#       |         Generate PDF right away (instead of DVI)
	@#       |
	@#       Call make for generating missing files

specs_check: $(SPECS_TEX)
	@echo Linting LaTeX document $(SPECS_TEX)
	@echo
	@echo ----------------------
	@test $(SPECS_LINTER) && $(SPECS_LINTER) --quiet --verbosity=3 $^
	@echo ----------------------
	@echo


clean:
	@latexmk -quiet -c -f $(wildcard *)

fclean:
	@latexmk -quiet -C -f $(wildcard *)

re: fclean all

.PHONY: all clean fclean specs specs_check $(SPECS_PDF)
