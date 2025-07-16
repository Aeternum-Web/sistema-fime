#!/bin/bash
echo "Building Tailwind CSS..."
npx tailwindcss -i ./wwwroot/css/input.css -o ./wwwroot/css/tailwind.css --minify
echo "Tailwind CSS built successfully!"