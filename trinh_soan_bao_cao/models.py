import json
import os
from typing import List, Dict, Any, Optional

class CodeFile:
    def __init__(self, filename: str = "", content: str = "", filepath: str = ""):
        self.filename = filename
        self.content = content
        self.filepath = filepath

    def to_dict(self) -> Dict[str, Any]:
        return {
            "filename": self.filename,
            "content": self.content,
            "filepath": self.filepath
        }

    @classmethod
    def from_dict(cls, data: Dict[str, Any]) -> "CodeFile":
        return cls(
            filename=data.get("filename", ""),
            content=data.get("content", ""),
            filepath=data.get("filepath", "")
        )


class Exercise:
    def __init__(
        self,
        title: str = "",
        folder: str = "",
        problem: str = "",
        diagram_image_path: str = "",
        code_files: Optional[List[CodeFile]] = None,
        manual_code_filename: str = "Program.cs",
        manual_code_content: str = "",
        output: str = "",
        idea: str = ""
    ):
        self.title = title
        self.folder = folder
        self.problem = problem
        self.diagram_image_path = diagram_image_path
        self.code_files = code_files if code_files is not None else []
        self.manual_code_filename = manual_code_filename
        self.manual_code_content = manual_code_content
        self.output = output
        self.idea = idea

    def get_effective_code_files(self) -> List[CodeFile]:
        """Trả về danh sách file code. Nếu không có file được chọn nhưng có gõ tay thì trả về code gõ tay."""
        if self.code_files and len(self.code_files) > 0:
            return self.code_files
        if self.manual_code_content.strip():
            return [CodeFile(
                filename=self.manual_code_filename or "Program.cs",
                content=self.manual_code_content
            )]
        return []

    def to_dict(self) -> Dict[str, Any]:
        return {
            "title": self.title,
            "folder": self.folder,
            "problem": self.problem,
            "diagram_image_path": self.diagram_image_path,
            "code_files": [cf.to_dict() for cf in self.code_files],
            "manual_code_filename": self.manual_code_filename,
            "manual_code_content": self.manual_code_content,
            "output": self.output,
            "idea": self.idea
        }

    @classmethod
    def from_dict(cls, data: Dict[str, Any]) -> "Exercise":
        code_files = [CodeFile.from_dict(cf) for cf in data.get("code_files", [])]
        return cls(
            title=data.get("title", ""),
            folder=data.get("folder", ""),
            problem=data.get("problem", ""),
            diagram_image_path=data.get("diagram_image_path", ""),
            code_files=code_files,
            manual_code_filename=data.get("manual_code_filename", "Program.cs"),
            manual_code_content=data.get("manual_code_content", ""),
            output=data.get("output", ""),
            idea=data.get("idea", "")
        )


class ReportProject:
    def __init__(
        self,
        main_title: str = "BÁO CÁO THỰC HÀNH",
        sub_title: str = "LẬP TRÌNH HƯỚNG ĐỐI TƯỢNG TRONG C#",
        subject: str = "Ngôn ngữ lập trình C# (NNLTCS)",
        author: str = "",
        topic_desc: str = "Class, Field, Property, Method, Constructor, Indexer, Interface, Delegate, Event, Kế thừa và Đa hình",
        exercises: Optional[List[Exercise]] = None
    ):
        self.main_title = main_title
        self.sub_title = sub_title
        self.subject = subject
        self.author = author
        self.topic_desc = topic_desc
        self.exercises = exercises if exercises is not None else []

    def to_dict(self) -> Dict[str, Any]:
        return {
            "main_title": self.main_title,
            "sub_title": self.sub_title,
            "subject": self.subject,
            "author": self.author,
            "topic_desc": self.topic_desc,
            "exercises": [ex.to_dict() for ex in self.exercises]
        }

    @classmethod
    def from_dict(cls, data: Dict[str, Any]) -> "ReportProject":
        exercises = [Exercise.from_dict(ex) for ex in data.get("exercises", [])]
        return cls(
            main_title=data.get("main_title", "BÁO CÁO THỰC HÀNH"),
            sub_title=data.get("sub_title", "LẬP TRÌNH HƯỚNG ĐỐI TƯỢNG TRONG C#"),
            subject=data.get("subject", "Ngôn ngữ lập trình C# (NNLTCS)"),
            author=data.get("author", ""),
            topic_desc=data.get("topic_desc", ""),
            exercises=exercises
        )

    def save_json(self, filepath: str) -> None:
        with open(filepath, "w", encoding="utf-8") as f:
            json.dump(self.to_dict(), f, ensure_ascii=False, indent=2)

    @classmethod
    def load_json(cls, filepath: str) -> "ReportProject":
        with open(filepath, "r", encoding="utf-8") as f:
            data = json.load(f)
        return cls.from_dict(data)
