@echo off
chcp 65001 >nul
title Trình Soạn Thảo Báo Cáo Thực Hành C#

echo =======================================================
echo    TRÌNH SOẠN THẢO BÁO CÁO THỰC HÀNH C# (XUẤT WORD DOCX)
echo =======================================================
echo.

cd /d "%~dp0"

if not exist "venv" (
    echo [1/3] Đang khởi tạo môi trường ảo Python (venv)...
    python -m venv venv
    if errorlevel 1 (
        echo [LỖI] Không thể tạo venv. Vui lòng kiểm tra cài đặt Python!
        pause
        exit /b 1
    )
    echo [2/3] Đang cài đặt các thư viện cần thiết từ requirements.txt...
    call venv\Scripts\activate.bat
    pip install --upgrade pip
    pip install -r requirements.txt
    echo [3/3] Cài đặt hoàn tất!
) else (
    call venv\Scripts\activate.bat
)

echo.
echo Đang khởi chạy ứng dụng...
python main.py

if errorlevel 1 (
    echo.
    echo [LỖI] Ứng dụng đã dừng với mã lỗi.
    pause
)
