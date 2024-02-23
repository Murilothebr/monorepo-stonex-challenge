FROM node:21-alpine as base

WORKDIR /app
COPY package*.json .
COPY . . 

RUN npm install

EXPOSE 3000

CMD [ "npm", "run", "dev" ]
