# Unusual backend

```shell
docker build -f UnusualBackend/Dockerfile -t unus_backend .
```

```shell
docker run -p 5050:8080 --name unus_backend unus_backend
```