#!/bin/bash

echo "🧹 Cleaning previous build artifacts..."
rm -rf obj bin

echo "🔧 Restoring packages..."
dotnet restore

if [ $? -ne 0 ]; then
    echo "❌ Package restore failed!"
    exit 1
fi

echo "🏗️ Building project..."
dotnet build --configuration Release --verbosity minimal

if [ $? -eq 0 ]; then
    echo "✅ Build successful!"
    echo "🚀 Testing publish..."
    dotnet publish -c Release -o out --verbosity minimal
    if [ $? -eq 0 ]; then
        echo "✅ Publish successful!"
        echo "🧹 Cleaning up test artifacts..."
        rm -rf out
    else
        echo "❌ Publish failed!"
        exit 1
    fi
else
    echo "❌ Build failed!"
    exit 1
fi