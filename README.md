Projet N°5 — WebApplicationProjetN5 - Formation: Développeur d'application back-end .NET (Rédigé avec l'aide de Chat GPT)

1. Présentation du projet

WebApplicationProjetN5 est une application web développée avec ASP.NET Core MVC permettant de publier et de consulter des annonces automobiles.

L'application propose un espace public accessible aux visiteurs ainsi qu'un espace d'administration sécurisé permettant de gérer les annonces de véhicules.

Ce projet met en œuvre le développement d'une application web en C#, la gestion des données avec Entity Framework Core, l'utilisation d'une base de données SQL Server et la gestion des utilisateurs et des autorisations avec ASP.NET Core Identity.

2. Fonctionnalités

Espace public:

Consulter les annonces de véhicules.

Afficher les informations détaillées d'un véhicule.

Consulter les caractéristiques des voitures et leurs photographies.

Naviguer dans l'application sans avoir besoin de créer un compte.


Espace administrateur:

Se connecter à l'espace d'administration.

Ajouter une nouvelle annonce automobile.

Modifier les informations d'une annonce existante.

Supprimer une annonce.

Ajouter une photographie lors de la création d'une annonce.

Renseigner les caractéristiques du véhicule, notamment la marque, le modèle et la finition.

L'accès aux fonctionnalités d'administration est réservé aux utilisateurs autorisés possédant le rôle Admin.


Création automatique du compte administrateur au démarrage de l'application.

Absence d'inscription publique : les visiteurs peuvent consulter les annonces sans créer de compte.

3. Technologies utilisées

Technologie

Utilisation

C#

Langage de programmation

.NET

Plateforme de développement

ASP.NET Core MVC

Architecture de l'application web

Razor Views

Création des interfaces utilisateur

HTML5

Structure des pages

CSS3

Mise en forme et présentation

Entity Framework Core

Accès aux données et mapping objet-relationnel

Microsoft SQL Server

Stockage des données

ASP.NET Core Identity

Authentification et gestion des rôles

Git / GitHub

Gestion du code source

4. Architecture du projet

L'application repose sur le modèle MVC (Model – View – Controller).

Models : représentent les données et les entités métier.

Views : contiennent les interfaces Razor et le code HTML associé.

Controllers : gèrent les requêtes HTTP et coordonnent les opérations de l'application.

ViewModels : permettent de transmettre aux vues les données nécessaires aux formulaires.

Data : contient le contexte Entity Framework Core et les éléments liés à l'accès aux données.

Identity : gère l'authentification et les rôles des utilisateurs.

wwwroot : contient les ressources statiques, notamment les feuilles de style CSS et les éventuelles images.

Le contexte de base de données utilisé par l'application est GarageDBContext.

5. Base de données

L'application utilise Microsoft SQL Server pour stocker les données.

Entity Framework Core assure la communication entre les objets C# et la base de données relationnelle.

Les migrations Entity Framework Core permettent de créer et de faire évoluer le schéma de la base de données.

La configuration de connexion utilise notamment la chaîne de connexion GarageDbLocalConnection.

Les tables liées à ASP.NET Core Identity permettent de gérer les utilisateurs, les rôles et les autorisations.

6. Installation et lancement

Prérequis

Visual Studio avec la prise en charge du développement ASP.NET et web.

Le SDK .NET correspondant à la version du projet.

Microsoft SQL Server ou SQL Server LocalDB.

Les outils Entity Framework Core nécessaires aux migrations.

Récupération du projet

Cloner le dépôt GitHub, puis ouvrir le fichier .sln ou .csproj dans Visual Studio.

git clone <URL_DU_DEPOT_GITHUB>

Se placer ensuite dans le répertoire du projet :

cd WebApplicationProjetN5

Configuration de la base de données

Vérifier la chaîne de connexion GarageDbLocalConnection dans le fichier de configuration approprié, généralement appsettings.json ou appsettings.Development.json.

Adapter le serveur SQL et le nom de la base de données à l'environnement local.

Ne pas publier de mots de passe ni d'autres informations sensibles dans le dépôt Git.

Installation des dépendances

Depuis le terminal du projet :

dotnet restore

Application des migrations

Si les migrations existent déjà et que la chaîne de connexion est configurée :

dotnet ef database update

Cette commande applique les migrations à la base de données configurée.

Si l'outil Entity Framework Core en ligne de commande n'est pas installé, il peut être nécessaire d'installer dotnet-ef dans une version compatible avec le projet.

Lancement de l'application

dotnet run

Ouvrir ensuite dans un navigateur l'adresse locale indiquée dans la console.

7. Sécurité

L'application utilise ASP.NET Core Identity pour l'authentification et le contrôle des accès.

Les principales mesures prévues dans l'application sont :

La protection des fonctionnalités d'administration par autorisation.

La distinction entre les visiteurs et les administrateurs grâce au rôle Admin.

La gestion sécurisée des mots de passe par ASP.NET Core Identity.

L'utilisation des mécanismes de protection des formulaires ASP.NET Core, notamment contre les requêtes CSRF lorsque les formulaires sont configurés en conséquence.

Le compte administrateur est créé automatiquement par le mécanisme d'initialisation de l'application. Ses identifiants doivent être configurés et conservés de manière sécurisée.

8. Objectifs pédagogiques

Ce projet permet de mettre en pratique :

Le développement d'une application web avec ASP.NET Core MVC.

La programmation orientée objet en C#.

La séparation des responsabilités entre modèles, vues et contrôleurs.

La création et la validation de formulaires web.

La gestion des fichiers et des photographies.

Les opérations CRUD : création, lecture, modification et suppression.

La manipulation d'une base de données relationnelle avec Entity Framework Core.

L'authentification, les rôles et l'autorisation avec ASP.NET Core Identity.

La mise en forme des interfaces avec HTML et CSS.

La gestion du code source avec Git.

9. Améliorations possibles

Parmi les évolutions envisageables :

Ajouter des filtres de recherche par marque, modèle, prix ou date.

Mettre en place une pagination des annonces.

Améliorer l'affichage responsive sur mobile et tablette.

Ajouter des validations métier complémentaires.

Améliorer la gestion et la suppression des photographies.

Ajouter des tests unitaires et des tests d'intégration.

10. Auteur

Projet réalisé dans le cadre du Projet N°5.

Nom du projet : WebApplicationProjetN5
Type : Application web de gestion et de publication d'annonces automobiles
Environnement : C#, ASP.NET Core MVC, Entity Framework Core et SQL Server
