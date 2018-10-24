# LectureNoteSharing

Its Front-end web application by Angular. It start in own Docker Image and host in Nginx server.

## Build Docker Image

To build write in cmd: ``docker build -t {name of your image} .``

## Run Docker Instance

To run write in cmd: ``docker run -p {Your port}:80 {name of your image}``

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via [Protractor](http://www.protractortest.org/).

## Nginx Configuration

You change configuration of Nginx which store in Docket.nginx.default.conf
