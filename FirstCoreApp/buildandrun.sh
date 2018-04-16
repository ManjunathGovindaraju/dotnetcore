docker build -t firstcoreapp .
docker run -it --rm -p 5000:80 --name myfirstcoreservice firstcoreapp

