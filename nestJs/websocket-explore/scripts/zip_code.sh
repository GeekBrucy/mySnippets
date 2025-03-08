# !/bin/bash

cd ..

zip -r nestjs-websocket-app.zip . -x "node_modules/*" -x "dist/*" -x ".git/*" -x ".elasticbeanstalk" -x "scripts/*"