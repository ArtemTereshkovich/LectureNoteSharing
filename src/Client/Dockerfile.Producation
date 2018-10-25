FROM node:alpine as builder

WORKDIR /app
COPY package*.json /app/
RUN npm install

COPY . /app/
ARG configuration=production
RUN npm run build -- --output-path=./dist/out --configuration $configuration

FROM nginx:1.15
COPY --from=builder /app/dist/out/ /usr/share/nginx/html
COPY --from=builder /app/Docker.nginx.default.conf /etc/nginx/nginx.conf