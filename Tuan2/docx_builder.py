import zipfile
import os
import xml.sax.saxutils as saxutils

def escape(text):
    return saxutils.escape(str(text))

def build_docx(filename, sections_data):
    # We will build standard OpenXML document structure
    
    content_types_xml = '''<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<Types xmlns="http://schemas.openxmlformats.org/package/2006/content-types">
    <Default Extension="rels" ContentType="application/vnd.openxmlformats-package.relationships+xml"/>
    <Default Extension="xml" ContentType="application/xml"/>
    <Override PartName="/word/document.xml" ContentType="application/vnd.openxmlformats-officedocument.wordprocessingml.document.main+xml"/>
    <Override PartName="/word/styles.xml" ContentType="application/vnd.openxmlformats-officedocument.wordprocessingml.styles+xml"/>
    <Override PartName="/word/settings.xml" ContentType="application/vnd.openxmlformats-officedocument.wordprocessingml.settings+xml"/>
</Types>'''

    rels_xml = '''<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<Relationships xmlns="http://schemas.openxmlformats.org/package/2006/relationships">
    <Relationship Id="rId1" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument" Target="word/document.xml"/>
</Relationships>'''

    doc_rels_xml = '''<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<Relationships xmlns="http://schemas.openxmlformats.org/package/2006/relationships">
    <Relationship Id="rId1" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/styles" Target="styles.xml"/>
    <Relationship Id="rId2" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/settings" Target="settings.xml"/>
</Relationships>'''

    settings_xml = '''<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<w:settings xmlns:w="http://schemas.openxmlformats.org/wordprocessingml/2006/main">
    <w:zoom w:percent="100"/>
</w:settings>'''

    styles_xml = '''<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<w:styles xmlns:w="http://schemas.openxmlformats.org/wordprocessingml/2006/main">
    <w:docDefaults>
        <w:rPrDefault>
            <w:rPr>
                <w:rFonts w:ascii="Times New Roman" w:hAnsi="Times New Roman" w:cs="Times New Roman"/>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
                <w:lang w:val="vi-VN"/>
            </w:rPr>
        </w:rPrDefault>
        <w:pPrDefault>
            <w:pPr>
                <w:spacing w:line="276" w:lineRule="auto" w:after="120"/>
            </w:pPr>
        </w:pPrDefault>
    </w:docDefaults>
    
    <w:style w:type="paragraph" w:styleId="Heading1">
        <w:name w:val="heading 1"/>
        <w:pPr>
            <w:spacing w:before="360" w:after="180"/>
            <w:pBdr>
                <w:bottom w:val="single" w:sz="18" w:space="4" w:color="1B365D"/>
            </w:pBdr>
        </w:pPr>
        <w:rPr>
            <w:rFonts w:ascii="Arial" w:hAnsi="Arial"/>
            <w:b/>
            <w:color w:val="1B365D"/>
            <w:sz w:val="34"/>
            <w:szCs w:val="34"/>
        </w:rPr>
    </w:style>
    
    <w:style w:type="paragraph" w:styleId="Heading2">
        <w:name w:val="heading 2"/>
        <w:pPr>
            <w:spacing w:before="240" w:after="120"/>
        </w:pPr>
        <w:rPr>
            <w:rFonts w:ascii="Arial" w:hAnsi="Arial"/>
            <w:b/>
            <w:color w:val="0B6623"/>
            <w:sz w:val="28"/>
            <w:szCs w:val="28"/>
        </w:rPr>
    </w:style>
    
    <w:style w:type="paragraph" w:styleId="Heading3">
        <w:name w:val="heading 3"/>
        <w:pPr>
            <w:spacing w:before="160" w:after="80"/>
        </w:pPr>
        <w:rPr>
            <w:rFonts w:ascii="Arial" w:hAnsi="Arial"/>
            <w:b/>
            <w:color w:val="333333"/>
            <w:sz w:val="26"/>
            <w:szCs w:val="26"/>
        </w:rPr>
    </w:style>
</w:styles>'''

    # Build document.xml body
    doc_body = []

    # Title Page / Header
    doc_body.append('''
        <w:p>
            <w:pPr>
                <w:jc w:val="center"/>
                <w:spacing w:before="300" w:after="100"/>
            </w:pPr>
            <w:r>
                <w:rPr>
                    <w:rFonts w:ascii="Arial" w:hAnsi="Arial"/>
                    <w:b/>
                    <w:color w:val="1B365D"/>
                    <w:sz w:val="44"/>
                    <w:szCs w:val="44"/>
                </w:rPr>
                <w:t>BÁO CÁO THỰC HÀNH 02</w:t>
            </w:r>
        </w:p>
        <w:p>
            <w:pPr>
                <w:jc w:val="center"/>
                <w:spacing w:before="0" w:after="300"/>
            </w:pPr>
            <w:r>
                <w:rPr>
                    <w:rFonts w:ascii="Arial" w:hAnsi="Arial"/>
                    <w:b/>
                    <w:color w:val="2B547E"/>
                    <w:sz w:val="32"/>
                    <w:szCs w:val="32"/>
                </w:rPr>
                <w:t>LẬP TRÌNH HƯỚNG ĐỐI TƯỢNG TRONG C#</w:t>
            </w:r>
        </w:p>
        
        <w:tbl>
            <w:tblPr>
                <w:tblW w:w="9200" w:type="dxa"/>
                <w:tblBorders>
                    <w:top w:val="single" w:sz="8" w:space="0" w:color="CCCCCC"/>
                    <w:left w:val="none"/>
                    <w:bottom w:val="single" w:sz="8" w:space="0" w:color="CCCCCC"/>
                    <w:right w:val="none"/>
                    <w:insideH w:val="none"/>
                    <w:insideV w:val="none"/>
                </w:tblBorders>
                <w:tblCellMar>
                    <w:top w:w="120" w:type="dxa"/>
                    <w:left w:w="160" w:type="dxa"/>
                    <w:bottom w:w="120" w:type="dxa"/>
                    <w:right w:w="160" w:type="dxa"/>
                </w:tblCellMar>
            </w:tblPr>
            <w:tr>
                <w:tc>
                    <w:tcPr>
                        <w:tcW w:w="9200" w:type="dxa"/>
                        <w:shd w:val="clear" w:color="auto" w:fill="F5F8FA"/>
                    </w:tcPr>
                    <w:p>
                        <w:pPr><w:spacing w:after="60"/></w:pPr>
                        <w:r><w:rPr><w:b/></w:rPr><w:t>Môn học: </w:t></w:r>
                        <w:r><w:t>Ngôn ngữ lập trình C# (NNLTCS)</w:t></w:r>
                    </w:p>
                    <w:p>
                        <w:pPr><w:spacing w:after="60"/></w:pPr>
                        <w:r><w:rPr><w:b/></w:rPr><w:t>Chủ đề: </w:t></w:r>
                        <w:r><w:t>Class, Field, Property, Method, Constructor, Overloading, Indexer, Interface, Delegate &amp; Event, Kế thừa và Đa hình</w:t></w:r>
                    </w:p>
                    <w:p>
                        <w:pPr><w:spacing w:after="0"/></w:pPr>
                        <w:r><w:rPr><w:b/></w:rPr><w:t>Tổng hợp: </w:t></w:r>
                        <w:r><w:t>Toàn bộ 18 bài tập thực hành (Bài 1.1 đến Bài 3.6)</w:t></w:r>
                    </w:p>
                </w:tc>
            </w:tr>
        </w:tbl>
        <w:p><w:pPr><w:spacing w:before="200" w:after="200"/></w:pPr></w:p>
    ''')

    for sec in sections_data:
        title = escape(sec['title'])
        folder = escape(sec.get('folder', ''))
        problem = escape(sec['problem'])
        code_files = sec.get('code_files', [])
        output_text = escape(sec['output'])
        idea_text = escape(sec['idea'])

        # Section Heading
        doc_body.append(f'''
        <w:p>
            <w:pPr>
                <w:pStyle w:val="Heading1"/>
            </w:pPr>
            <w:r>
                <w:t>{title}</w:t>
            </w:r>
            <w:r>
                <w:rPr>
                    <w:rFonts w:ascii="Consolas" w:hAnsi="Consolas"/>
                    <w:sz w:val="22"/>
                    <w:color w:val="666666"/>
                    <w:b w:val="0"/>
                </w:rPr>
                <w:t>  [Thư mục: {folder}]</w:t>
            </w:r>
        </w:p>
        ''')

        # 1. Đề bài (Problem statement box)
        doc_body.append(f'''
        <w:p>
            <w:pPr><w:pStyle w:val="Heading2"/></w:pPr>
            <w:r><w:t>1. Đề bài</w:t></w:r>
        </w:p>
        <w:tbl>
            <w:tblPr>
                <w:tblW w:w="9200" w:type="dxa"/>
                <w:tblBorders>
                    <w:top w:val="single" w:sz="6" w:space="0" w:color="0088CC"/>
                    <w:left w:val="single" w:sz="24" w:space="0" w:color="0088CC"/>
                    <w:bottom w:val="single" w:sz="6" w:space="0" w:color="0088CC"/>
                    <w:right w:val="single" w:sz="6" w:space="0" w:color="0088CC"/>
                </w:tblBorders>
                <w:tblCellMar>
                    <w:top w:w="120" w:type="dxa"/>
                    <w:left w:w="160" w:type="dxa"/>
                    <w:bottom w:w="120" w:type="dxa"/>
                    <w:right w:w="160" w:type="dxa"/>
                </w:tblCellMar>
            </w:tblPr>
            <w:tr>
                <w:tc>
                    <w:tcPr>
                        <w:tcW w:w="9200" w:type="dxa"/>
                        <w:shd w:val="clear" w:color="auto" w:fill="F0F7FD"/>
                    </w:tcPr>
                    <w:p>
                        <w:pPr><w:spacing w:after="0"/><w:jc w:val="both"/></w:pPr>
                        <w:r>
                            <w:rPr><w:color w:val="1A3644"/></w:rPr>
                            <w:t>{problem.replace(chr(10), '</w:t></w:r></w:p><w:p><w:pPr><w:spacing w:after="60"/><w:jc w:val="both"/></w:pPr><w:r><w:rPr><w:color w:val="1A3644"/></w:rPr><w:t>')}</w:t>
                        </w:r>
                    </w:p>
                </w:tc>
            </w:tr>
        </w:tbl>
        <w:p><w:pPr><w:spacing w:before="100" w:after="60"/></w:pPr></w:p>
        ''')

        # 2. Sơ đồ lớp (Class Diagram Placeholder)
        doc_body.append('''
        <w:p>
            <w:pPr><w:pStyle w:val="Heading2"/></w:pPr>
            <w:r><w:t>2. Sơ đồ lớp (Class Diagram)</w:t></w:r>
        </w:p>
        <w:tbl>
            <w:tblPr>
                <w:tblW w:w="9200" w:type="dxa"/>
                <w:tblBorders>
                    <w:top w:val="dashed" w:sz="12" w:space="0" w:color="888888"/>
                    <w:left w:val="dashed" w:sz="12" w:space="0" w:color="888888"/>
                    <w:bottom w:val="dashed" w:sz="12" w:space="0" w:color="888888"/>
                    <w:right w:val="dashed" w:sz="12" w:space="0" w:color="888888"/>
                </w:tblBorders>
                <w:tblCellMar>
                    <w:top w:w="240" w:type="dxa"/>
                    <w:left w:w="200" w:type="dxa"/>
                    <w:bottom w:w="240" w:type="dxa"/>
                    <w:right w:w="200" w:type="dxa"/>
                </w:tblCellMar>
            </w:tblPr>
            <w:tr>
                <w:tc>
                    <w:tcPr>
                        <w:tcW w:w="9200" w:type="dxa"/>
                        <w:shd w:val="clear" w:color="auto" w:fill="FAFAFA"/>
                    </w:tcPr>
                    <w:p>
                        <w:pPr>
                            <w:jc w:val="center"/>
                            <w:spacing w:before="200" w:after="80"/>
                        </w:pPr>
                        <w:r>
                            <w:rPr>
                                <w:rFonts w:ascii="Arial" w:hAnsi="Arial"/>
                                <w:b/>
                                <w:color w:val="555555"/>
                                <w:sz w:val="24"/>
                            </w:rPr>
                            <w:t>[ KHU VỰC CHÈN ẢNH SƠ ĐỒ LỚP (CLASS DIAGRAM) ]</w:t>
                        </w:r>
                    </w:p>
                    <w:p>
                        <w:pPr>
                            <w:jc w:val="center"/>
                            <w:spacing w:before="0" w:after="200"/>
                        </w:pPr>
                        <w:r>
                            <w:rPr>
                                <w:i/>
                                <w:color w:val="888888"/>
                                <w:sz w:val="20"/>
                            </w:rPr>
                            <w:t>(Dán hình ảnh thiết kế sơ đồ lớp UML của bài tập vào đây)</w:t>
                        </w:r>
                    </w:p>
                </w:tc>
            </w:tr>
        </w:tbl>
        <w:p><w:pPr><w:spacing w:before="100" w:after="60"/></w:pPr></w:p>
        ''')

        # 3. Mã nguồn (Source Code)
        doc_body.append('''
        <w:p>
            <w:pPr><w:pStyle w:val="Heading2"/></w:pPr>
            <w:r><w:t>3. Mã nguồn C# (Source Code)</w:t></w:r>
        </w:p>
        ''')

        for code_file in code_files:
            cf_name = escape(code_file['filename'])
            cf_code = escape(code_file['content'])
            
            # Code block header
            doc_body.append(f'''
            <w:p>
                <w:pPr><w:spacing w:before="100" w:after="40"/></w:pPr>
                <w:r>
                    <w:rPr><w:b/><w:color w:val="333333"/><w:sz w:val="22"/></w:rPr>
                    <w:t>• File: {cf_name}</w:t>
                </w:r>
            </w:p>
            ''')

            # Code table
            lines_xml = []
            for line in cf_code.split('\n'):
                escaped_line = line.replace(' ', '&#160;')
                lines_xml.append(f'''
                <w:p>
                    <w:pPr>
                        <w:spacing w:before="0" w:after="0" w:line="220" w:lineRule="auto"/>
                    </w:pPr>
                    <w:r>
                        <w:rPr>
                            <w:rFonts w:ascii="Consolas" w:hAnsi="Consolas" w:cs="Consolas"/>
                            <w:sz w:val="19"/>
                            <w:szCs w:val="19"/>
                            <w:color w:val="222222"/>
                        </w:rPr>
                        <w:t xml:space="preserve">{escaped_line if escaped_line else ' '}</w:t>
                    </w:r>
                </w:p>
                ''')
            all_lines = "".join(lines_xml)

            doc_body.append(f'''
            <w:tbl>
                <w:tblPr>
                    <w:tblW w:w="9200" w:type="dxa"/>
                    <w:tblBorders>
                        <w:top w:val="single" w:sz="4" w:space="0" w:color="D0D0D0"/>
                        <w:left w:val="single" w:sz="16" w:space="0" w:color="007ACC"/>
                        <w:bottom w:val="single" w:sz="4" w:space="0" w:color="D0D0D0"/>
                        <w:right w:val="single" w:sz="4" w:space="0" w:color="D0D0D0"/>
                    </w:tblBorders>
                    <w:tblCellMar>
                        <w:top w:w="80" w:type="dxa"/>
                        <w:left w:w="120" w:type="dxa"/>
                        <w:bottom w:w="80" w:type="dxa"/>
                        <w:right w:w="120" w:type="dxa"/>
                    </w:tblCellMar>
                </w:tblPr>
                <w:tr>
                    <w:tc>
                        <w:tcPr>
                            <w:tcW w:w="9200" w:type="dxa"/>
                            <w:shd w:val="clear" w:color="auto" w:fill="F8F9FA"/>
                        </w:tcPr>
                        {all_lines}
                    </w:tc>
                </w:tr>
            </w:tbl>
            <w:p><w:pPr><w:spacing w:before="60" w:after="60"/></w:pPr></w:p>
            ''')

        # 4. Kết quả chạy thử (Test Run Output)
        doc_body.append('''
        <w:p>
            <w:pPr><w:pStyle w:val="Heading2"/></w:pPr>
            <w:r><w:t>4. Kết quả chạy thử (Test Run / Output)</w:t></w:r>
        </w:p>
        ''')

        output_lines_xml = []
        for line in output_text.split('\n'):
            escaped_line = line.replace(' ', '&#160;')
            output_lines_xml.append(f'''
            <w:p>
                <w:pPr>
                    <w:spacing w:before="0" w:after="0" w:line="220" w:lineRule="auto"/>
                </w:pPr>
                <w:r>
                    <w:rPr>
                        <w:rFonts w:ascii="Consolas" w:hAnsi="Consolas" w:cs="Consolas"/>
                        <w:sz w:val="19"/>
                        <w:szCs w:val="19"/>
                        <w:color w:val="00FF66"/>
                    </w:rPr>
                    <w:t xml:space="preserve">{escaped_line if escaped_line else ' '}</w:t>
                </w:r>
            </w:p>
            ''')
        all_output = "".join(output_lines_xml)

        doc_body.append(f'''
        <w:tbl>
            <w:tblPr>
                <w:tblW w:w="9200" w:type="dxa"/>
                <w:tblBorders>
                    <w:top w:val="single" w:sz="6" w:space="0" w:color="111111"/>
                    <w:left w:val="single" w:sz="6" w:space="0" w:color="111111"/>
                    <w:bottom w:val="single" w:sz="6" w:space="0" w:color="111111"/>
                    <w:right w:val="single" w:sz="6" w:space="0" w:color="111111"/>
                </w:tblBorders>
                <w:tblCellMar>
                    <w:top w:w="100" w:type="dxa"/>
                    <w:left w:w="140" w:type="dxa"/>
                    <w:bottom w:w="100" w:type="dxa"/>
                    <w:right w:w="140" w:type="dxa"/>
                </w:tblCellMar>
            </w:tblPr>
            <w:tr>
                <w:tc>
                    <w:tcPr>
                        <w:tcW w:w="9200" w:type="dxa"/>
                        <w:shd w:val="clear" w:color="auto" w:fill="1E1E1E"/>
                    </w:tcPr>
                    {all_output}
                </w:tc>
            </w:tr>
        </w:tbl>
        <w:p><w:pPr><w:spacing w:before="100" w:after="60"/></w:pPr></w:p>
        ''')

        # 5. Ý tưởng bài làm / Thiết kế giải pháp (Idea / Design)
        doc_body.append(f'''
        <w:p>
            <w:pPr><w:pStyle w:val="Heading2"/></w:pPr>
            <w:r><w:t>5. Ý tưởng bài làm và Thiết kế giải pháp</w:t></w:r>
        </w:p>
        <w:tbl>
            <w:tblPr>
                <w:tblW w:w="9200" w:type="dxa"/>
                <w:tblBorders>
                    <w:top w:val="single" w:sz="6" w:space="0" w:color="2E7D32"/>
                    <w:left w:val="single" w:sz="24" w:space="0" w:color="2E7D32"/>
                    <w:bottom w:val="single" w:sz="6" w:space="0" w:color="2E7D32"/>
                    <w:right w:val="single" w:sz="6" w:space="0" w:color="2E7D32"/>
                </w:tblBorders>
                <w:tblCellMar>
                    <w:top w:w="120" w:type="dxa"/>
                    <w:left w:w="160" w:type="dxa"/>
                    <w:bottom w:w="120" w:type="dxa"/>
                    <w:right w:w="160" w:type="dxa"/>
                </w:tblCellMar>
            </w:tblPr>
            <w:tr>
                <w:tc>
                    <w:tcPr>
                        <w:tcW w:w="9200" w:type="dxa"/>
                        <w:shd w:val="clear" w:color="auto" w:fill="F4FAF4"/>
                    </w:tcPr>
                    <w:p>
                        <w:pPr><w:spacing w:after="0"/><w:jc w:val="both"/></w:pPr>
                        <w:r>
                            <w:rPr><w:color w:val="1C3B1E"/></w:rPr>
                            <w:t>{idea_text.replace(chr(10), '</w:t></w:r></w:p><w:p><w:pPr><w:spacing w:after="60"/><w:jc w:val="both"/></w:pPr><w:r><w:rPr><w:color w:val="1C3B1E"/></w:rPr><w:t>')}</w:t>
                        </w:r>
                    </w:p>
                </w:tc>
            </w:tr>
        </w:tbl>
        <w:p><w:pPr><w:spacing w:before="160" w:after="240"/></w:pPr></w:p>
        ''')

    # Document wrapper
    body_content = "".join(doc_body)
    document_xml = f'''<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<w:document xmlns:w="http://schemas.openxmlformats.org/wordprocessingml/2006/main"
            xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships">
    <w:body>
        {body_content}
        <w:sectPr>
            <w:pgSz w:w="11906" w:h="16838"/>
            <w:pgMar w:top="1134" w:right="1134" w:bottom="1134" w:left="1134" w:header="720" w:footer="720" w:gutter="0"/>
        </w:sectPr>
    </w:body>
</w:document>'''

    # Write to zip
    with zipfile.ZipFile(filename, 'w', zipfile.ZIP_DEFLATED) as docx:
        docx.writestr('[Content_Types].xml', content_types_xml)
        docx.writestr('_rels/.rels', rels_xml)
        docx.writestr('word/_rels/document.xml.rels', doc_rels_xml)
        docx.writestr('word/document.xml', document_xml)
        docx.writestr('word/styles.xml', styles_xml)
        docx.writestr('word/settings.xml', settings_xml)

    print(f"Successfully generated docx file: {filename}")

if __name__ == '__main__':
    print("Builder ready.")
