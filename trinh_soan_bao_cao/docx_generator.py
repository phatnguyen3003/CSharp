import os
import zipfile
import xml.sax.saxutils as saxutils
from typing import Optional
from models import ReportProject, Exercise

def escape_xml(text: str) -> str:
    if text is None:
        return ""
    return saxutils.escape(str(text))

def generate_report_docx(project: ReportProject, output_path: str) -> None:
    """Tạo tệp Word .docx chuẩn format bài tập hướng đối tượng từ đối tượng ReportProject."""
    
    content_types_xml = '''<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<Types xmlns="http://schemas.openxmlformats.org/package/2006/content-types">
    <Default Extension="rels" ContentType="application/vnd.openxmlformats-package.relationships+xml"/>
    <Default Extension="xml" ContentType="application/xml"/>
    <Default Extension="png" ContentType="image/png"/>
    <Default Extension="jpg" ContentType="image/jpeg"/>
    <Default Extension="jpeg" ContentType="image/jpeg"/>
    <Default Extension="bmp" ContentType="image/bmp"/>
    <Default Extension="gif" ContentType="image/gif"/>
    <Override PartName="/word/document.xml" ContentType="application/vnd.openxmlformats-officedocument.wordprocessingml.document.main+xml"/>
    <Override PartName="/word/styles.xml" ContentType="application/vnd.openxmlformats-officedocument.wordprocessingml.styles+xml"/>
    <Override PartName="/word/settings.xml" ContentType="application/vnd.openxmlformats-officedocument.wordprocessingml.settings+xml"/>
</Types>'''

    rels_xml = '''<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<Relationships xmlns="http://schemas.openxmlformats.org/package/2006/relationships">
    <Relationship Id="rId1" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument" Target="word/document.xml"/>
</Relationships>'''

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

    settings_xml = '''<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<w:settings xmlns:w="http://schemas.openxmlformats.org/wordprocessingml/2006/main">
    <w:zoom w:percent="100"/>
</w:settings>'''

    # Image relationship tracking
    image_files_to_pack = []  # list of (zip_path, local_abs_path)
    image_rel_id_map = {}     # local_abs_path -> (rel_id, target_zip_name)
    next_r_id = 3
    image_counter = 1

    for ex in project.exercises:
        if ex.diagram_image_path and os.path.exists(ex.diagram_image_path):
            img_path = os.path.abspath(ex.diagram_image_path)
            if img_path not in image_rel_id_map:
                ext = os.path.splitext(img_path)[1].lower()
                if not ext:
                    ext = ".png"
                target_media_name = f"image{image_counter}{ext}"
                r_id = f"rIdImg{image_counter}"
                image_rel_id_map[img_path] = (r_id, target_media_name)
                image_files_to_pack.append((f"word/media/{target_media_name}", img_path))
                image_counter += 1

    # Build document rels xml
    doc_rels_items = [
        '<Relationship Id="rId1" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/styles" Target="styles.xml"/>',
        '<Relationship Id="rId2" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/settings" Target="settings.xml"/>'
    ]
    for img_path, (r_id, target_media_name) in image_rel_id_map.items():
        doc_rels_items.append(
            f'<Relationship Id="{r_id}" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/image" Target="media/{target_media_name}"/>'
        )

    doc_rels_xml = f'''<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<Relationships xmlns="http://schemas.openxmlformats.org/package/2006/relationships">
    {"".join(doc_rels_items)}
</Relationships>'''

    # Document body
    doc_body = []

    # Title & Metadata table
    main_title = escape_xml(project.main_title or "BÁO CÁO THỰC HÀNH")
    sub_title = escape_xml(project.sub_title or "LẬP TRÌNH HƯỚNG ĐỐI TƯỢNG TRONG C#")
    subject = escape_xml(project.subject or "Ngôn ngữ lập trình C#")
    author = escape_xml(project.author)
    topic_desc = escape_xml(project.topic_desc)

    doc_body.append(f'''
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
                <w:t>{main_title}</w:t>
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
                <w:t>{sub_title}</w:t>
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
                        <w:r><w:t>{subject}</w:t></w:r>
                    </w:p>
                    {f"""
                    <w:p>
                        <w:pPr><w:spacing w:after="60"/></w:pPr>
                        <w:r><w:rPr><w:b/></w:rPr><w:t>Người thực hiện: </w:t></w:r>
                        <w:r><w:t>{author}</w:t></w:r>
                    </w:p>
                    """ if author else ""}
                    {f"""
                    <w:p>
                        <w:pPr><w:spacing w:after="60"/></w:pPr>
                        <w:r><w:rPr><w:b/></w:rPr><w:t>Chủ đề: </w:t></w:r>
                        <w:r><w:t>{topic_desc}</w:t></w:r>
                    </w:p>
                    """ if topic_desc else ""}
                    <w:p>
                        <w:pPr><w:spacing w:after="0"/></w:pPr>
                        <w:r><w:rPr><w:b/></w:rPr><w:t>Số lượng bài: </w:t></w:r>
                        <w:r><w:t>{len(project.exercises)} bài tập</w:t></w:r>
                    </w:p>
                </w:tc>
            </w:tr>
        </w:tbl>
        <w:p><w:pPr><w:spacing w:before="200" w:after="200"/></w:pPr></w:p>
    ''')

    # Each Exercise
    for idx, ex in enumerate(project.exercises):
        title = escape_xml(ex.title or f"Bài tập {idx + 1}")
        folder = escape_xml(ex.folder)
        problem = escape_xml(ex.problem)
        code_files = ex.get_effective_code_files()
        output_text = escape_xml(ex.output)
        idea_text = escape_xml(ex.idea)

        # Section Heading
        folder_suffix = f"  [Thư mục: {folder}]" if folder else ""
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
                <w:t>{folder_suffix}</w:t>
            </w:r>
        </w:p>
        ''')

        # 1. Đề bài (Problem statement box)
        if problem.strip():
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

        # 2. Sơ đồ lớp (Class Diagram)
        doc_body.append('''
        <w:p>
            <w:pPr><w:pStyle w:val="Heading2"/></w:pPr>
            <w:r><w:t>2. Sơ đồ lớp (Class Diagram)</w:t></w:r>
        </w:p>
        ''')

        # Check if user provided an image
        has_image = False
        img_r_id = ""
        if ex.diagram_image_path and os.path.exists(ex.diagram_image_path):
            img_abs = os.path.abspath(ex.diagram_image_path)
            if img_abs in image_rel_id_map:
                img_r_id = image_rel_id_map[img_abs][0]
                has_image = True

        if has_image:
            # Insert actual drawing image in OpenXML
            doc_body.append(f'''
            <w:p>
                <w:pPr>
                    <w:jc w:val="center"/>
                    <w:spacing w:before="120" w:after="120"/>
                </w:pPr>
                <w:r>
                    <w:drawing>
                        <wp:inline distT="0" distB="0" distL="0" distR="0" xmlns:wp="http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing">
                            <wp:extent cx="5486400" cy="3657600"/>
                            <wp:effectExtent l="0" t="0" r="0" b="0"/>
                            <wp:docPr id="{idx+1}" name="Diagram_{idx+1}"/>
                            <wp:cNvGraphicFramePr>
                                <a:graphicFrameLocks noChangeAspect="1" xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main"/>
                            </wp:cNvGraphicFramePr>
                            <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
                                <a:graphicData uri="http://schemas.openxmlformats.org/drawingml/2006/picture">
                                    <pic:pic xmlns:pic="http://schemas.openxmlformats.org/drawingml/2006/picture">
                                        <pic:nvPicPr>
                                            <pic:cNvPr id="{idx+1}" name="Diagram_{idx+1}"/>
                                            <pic:cNvPicPr/>
                                        </pic:nvPicPr>
                                        <pic:blipFill>
                                            <a:blip r:embed="{img_r_id}"/>
                                            <a:stretch>
                                                <a:fillRect/>
                                            </a:stretch>
                                        </pic:blipFill>
                                        <pic:spPr>
                                            <a:xfrm>
                                                <a:off x="0" y="0"/>
                                                <a:ext cx="5486400" cy="3657600"/>
                                            </a:xfrm>
                                            <a:prstGeom prst="rect">
                                                <a:avLst/>
                                            </a:prstGeom>
                                        </pic:spPr>
                                    </pic:pic>
                                </a:graphicData>
                            </a:graphic>
                        </wp:inline>
                    </w:drawing>
                </w:r>
            </w:p>
            <w:p>
                <w:pPr>
                    <w:jc w:val="center"/>
                    <w:spacing w:before="0" w:after="160"/>
                </w:pPr>
                <w:r>
                    <w:rPr>
                        <w:i/>
                        <w:sz w:val="20"/>
                        <w:color w:val="666666"/>
                    </w:rPr>
                    <w:t>Hình: Sơ đồ lớp (Class Diagram) - {title}</w:t>
                </w:r>
            </w:p>
            ''')
        else:
            # Insert Placeholder
            doc_body.append('''
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

        # 3. Mã nguồn C# (Source code)
        doc_body.append('''
        <w:p>
            <w:pPr><w:pStyle w:val="Heading2"/></w:pPr>
            <w:r><w:t>3. Mã nguồn C# (Source Code)</w:t></w:r>
        </w:p>
        ''')

        if not code_files:
            doc_body.append('''
            <w:p>
                <w:r><w:rPr><w:i/><w:color w:val="888888"/></w:rPr><w:t>(Chưa có mã nguồn)</w:t></w:r>
            </w:p>
            ''')
        else:
            for cf in code_files:
                cf_name = escape_xml(cf.filename or "Program.cs")
                cf_code = escape_xml(cf.content)

                doc_body.append(f'''
                <w:p>
                    <w:pPr><w:spacing w:before="100" w:after="40"/></w:pPr>
                    <w:r>
                        <w:rPr><w:b/><w:color w:val="333333"/><w:sz w:val="22"/></w:rPr>
                        <w:t>• File: {cf_name}</w:t>
                    </w:r>
                </w:p>
                ''')

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

        output_content = output_text if output_text.strip() else "(Chưa có kết quả chạy thử)"
        output_lines_xml = []
        for line in output_content.split('\n'):
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
        ''')

        idea_content = idea_text if idea_text.strip() else "(Chưa có phân tích ý tưởng bài làm)"
        doc_body.append(f'''
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
                            <w:t>{idea_content.replace(chr(10), '</w:t></w:r></w:p><w:p><w:pPr><w:spacing w:after="60"/><w:jc w:val="both"/></w:pPr><w:r><w:rPr><w:color w:val="1C3B1E"/></w:rPr><w:t>')}</w:t>
                        </w:r>
                    </w:p>
                </w:tc>
            </w:tr>
        </w:tbl>
        <w:p><w:pPr><w:spacing w:before="160" w:after="240"/></w:pPr></w:p>
        ''')

    # Wrap document
    body_content = "".join(doc_body)
    document_xml = f'''<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<w:document xmlns:w="http://schemas.openxmlformats.org/wordprocessingml/2006/main"
            xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships"
            xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main"
            xmlns:pic="http://schemas.openxmlformats.org/drawingml/2006/picture"
            xmlns:wp="http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing">
    <w:body>
        {body_content}
        <w:sectPr>
            <w:pgSz w:w="11906" w:h="16838"/>
            <w:pgMar w:top="1134" w:right="1134" w:bottom="1134" w:left="1134" w:header="720" w:footer="720" w:gutter="0"/>
        </w:sectPr>
    </w:body>
</w:document>'''

    # Ensure output directory exists
    out_dir = os.path.dirname(os.path.abspath(output_path))
    if out_dir and not os.path.exists(out_dir):
        os.makedirs(out_dir, exist_ok=True)

    # Pack into docx ZIP archive
    with zipfile.ZipFile(output_path, 'w', zipfile.ZIP_DEFLATED) as docx:
        docx.writestr('[Content_Types].xml', content_types_xml)
        docx.writestr('_rels/.rels', rels_xml)
        docx.writestr('word/_rels/document.xml.rels', doc_rels_xml)
        docx.writestr('word/document.xml', document_xml)
        docx.writestr('word/styles.xml', styles_xml)
        docx.writestr('word/settings.xml', settings_xml)
        
        # Add actual images if any
        for zip_target, local_img in image_files_to_pack:
            if os.path.exists(local_img):
                with open(local_img, 'rb') as img_f:
                    docx.writestr(zip_target, img_f.read())

    print(f"[SUCCESS] Exported DOCX to: {output_path}")
