#!/bin/bash
# validar as configurações das credenciais da aws no computador
# aws configure

echo "Restore das dependencias"
dotnet restore

echo "Build dos projetos"
dotnet build --no-restore

echo "Criando o pacote para deploy"
cd src/LinkManager.Api.GraphQL
dotnet new tool-manifest
dotnet tool install Amazon.Lambda.Tools
dotnet lambda package

echo "Instalando o serverless framework"
npm install -g serverless

echo "Fazendo o deploy para produção"
serverless deploy --stage production

echo "Pressione uma tecla para fechar"
read