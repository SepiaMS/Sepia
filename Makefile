SPECS_LINTER = ChkTeX
SPECS_NAME = doc_specs
SPECS_IDIR = src/doc_specs
SPECS_ODIR = doc
SPECS_PDF = $(SPECS_IDIR)/$(SPECS_NAME).pdf
SPECS_TEX = $(SPECS_IDIR)/$(SPECS_NAME).tex

all: specs

specs: $(SPECS_PDF)

specs_f: $(SPECS_TEX)
	@#Forces the compilation, without checking for typos
	@latexmk -outdir=$(SPECS_ODIR) -use-make -pdf -pdflatex="pdflatex -interaction=nonstopmode" -jobname=$(SPECS_IDIR)/$(SPECS_NAME) -quiet $<

check: specs_check

$(SPECS_PDF): $(SPECS_TEX) specs_check
	@latexmk -outdir=$(SPECS_ODIR) -use-make -pdf -pdflatex="pdflatex -interaction=nonstopmode" -quiet $<
	@#                             ^         ^
	@#                             |         Generate PDF right away (instead of DVI)
	@#                             |
	@#                             Call make for generating missing files
	@echo Output PDF should now be in directory $(SPECS_ODIR).

specs_check: $(SPECS_TEX)
	@echo Linting LaTeX document $(SPECS_TEX)
	@echo
	@echo ----------------------
	@test $(SPECS_LINTER) && $(SPECS_LINTER) --quiet --verbosity=3 $^
	@echo ----------------------
	@echo

clean:
	@latexmk -quiet -cd -c -f $(SPECS_TEX)

fclean:
	$(RM) $(SPECS_PDF)
	@latexmk -quiet -cd -C -f $(SPECS_TEX)

re: fclean all

.PHONY: all clean fclean specs specs_f spec_check $(SPECS_PDF)
