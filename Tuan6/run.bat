
@echo off
title SQL Server 2022

docker inspect mssql >nul 2>&1

if %errorlevel% equ 0 (
    echo Container mssql da ton tai. Dang khoi dong...
    docker start mssql
) else (
    echo Chua co container. Dang tao moi...
    docker run -d ^
        --name mssql ^
        -e ACCEPT_EULA=Y ^
        -e MSSQL_SA_PASSWORD="SqlServer@2026" ^
        -e MSSQL_PID=Developer ^
        -v mssql_data:/var/opt/mssql ^
        -p 1433:1433 ^
        mcr.microsoft.com/mssql/server:2022-latest
)

echo.
echo Trang thai container:
docker ps -a --filter "name=mssql"

pause
