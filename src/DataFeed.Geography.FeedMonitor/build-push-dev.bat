for /f "tokens=1,2,3 delims=/- " %%a in ("%date%") do @set D=%%a%%c%%b
for /f "tokens=1,2,3 delims=:." %%a in ("%time%") do @set T=%%a%%b%%c
set T=%T: =0%
set currenttime=%D%%T%
set imagetag=datafeed-geography:%currenttime%
set dockerserver=172.16.0.2:5001
set projectname=dev
set image=%dockerserver%/%projectname%/%imagetag%
docker build --rm -t %imagetag% -f Dockerfile ..
docker tag %imagetag% %image%
docker login -u=dev -p=Dev@123456 %dockerserver%
docker push %image%
pause