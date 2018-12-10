#!/bin/bash
cd ../..
docker build -t dolittle/sentry-studio-backend -f Source/Studio/Dockerfile.backend .
docker build -t dolittle/sentry-studio-frontend -f Source/Studio/Dockerfile.frontend .
cd Source/Studio