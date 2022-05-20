# syntax=docker/dockerfile:1

FROM node:17.9.0

WORKDIR /app

COPY ["package.json", "yarn.lock", "/app/"]

RUN yarn install

CMD ["yarn", "dev"]
EXPOSE 3000