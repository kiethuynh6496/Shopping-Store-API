# build stage
FROM node:14 as build
WORKDIR /src
COPY package.json ./

RUN npm install
COPY . .
RUN npm run build

# production stage
FROM nginx:stable-alpine as production
WORKDIR /usr/share/nginx/html
RUN rm -rf ./*
COPY --from=build /src/build .
COPY --from=build /src/nginx/nginx.conf /etc/nginx/conf.d/default.conf
EXPOSE 80

ENTRYPOINT ["nginx", "-g", "daemon off;"]