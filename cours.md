# Introduction aux patterns de conception

Un design pattern ou pattern de conception consiste en un schéma à objets qui forme une solution à un problème connu et fréquent. Le schéma à objets est constitué par un ensemble d’objets décrits par des classes et des relations liant les objets.

Les patterns repondent a des problemes de conception de logiciel dans le cadre de la programmation objet. Ce sont des solutions connues et eprouvees dont la conception provient de l'experience de developpeurs. On peut dire qu'il n'y pas de theorie derriere les patterns, mais plutot une pratique.

Livre : Gang of four (design pattern)

![Alt text](image.png)
Titre : Template Method

Commande -> Classe
CommandeFrance -> Sous classe
+ () -> procédure


Les patterns sont basés sur les bonnes pratiques de la programmation par objets. Par exemple, la figure 1- 1.1 donne l’exemple du pattern qui sera décrit au chapitre Le pattern Template Method.Dans ce pattern, la méthode invoque la méthode qui est abstraite dans la classe . Elle est définie dans les sous-classes de à savoir les classes et . En effet, le taux de TVA varie en fonction du pays. Elle introduit un algorithme basé sur une méthode abstraite.

Ce pattern est basé sur le polymorphisme, une propriété importante de la programmation par objets. Le montant d’une commande en France ou au Luxembourg est soumis à la TVA. Mais le taux n’est pas le même, le calcul de TVA est donc différent en France et au Luxembourg. Par conséquent, le pattern constitue une bonne illustration du polymorphisme.Template method

## La description des patterns

Dans ce cours nous avons choisi de decrire les patterns de la maniere suivante:

le langage UML
le langage C#
Pour chaque pattern nous presentons :

Nom
description
exmemple sous forme de diagramme UML
structure generique du pattern
les cas d'utilisation
un exemple de code en C#



## Liste des patterns de conception

**client** : Autre bout de logiciel qui se charge de 


Abstract Factory: a pour objectif la creation d'une famille d'objets sans devoir preciser leur classe concrete.
Builder: permet de separer la construction d'objets complexes de leur implementation de maniere a ce qu'un client puisser creer des objets complexes sans avoir a se soucier de leur implementation.
Factory Method
Prototype
Singleton
Adapter
Bridge
Composite
Decorator
Facade
Flyweight
Proxy
Chain of Responsibility
Command
Interpreter
Iterator
Mediator
Memento
Observer
State
Strategy
Template Method
Visitor

## Comment choisir et utiliser un pattern correctement ?

Classe avec méthode abstraite 


Voici la representation abstraite d'un pattern de conception:
![Alt text](image-2.png)

## Organisation du cours :

Les patterns de conceptions sont organisees en 3 categories:

**Pattern de creation** : Ces patterns fournissent des mecanismes de creation d'objets qui augmentent la flexibilite et la reutilisabilite du code existant.
**Structural patterns** : Ces patterns expliquent comment creer des structures de classes et d'objets plus complexes a partir de structures simples.
**Behavioral patterns** : Ces patterns s'occupent de l'interaction flexible et de la distribution des responsabilites entre les objets.

## Contexte du cours 

Nous allons nous placer dans le contexte d'un site web de ventes/locations de vehicules en ligne (voitures, motos, velos, etc...).

CDC :

Le site permet d’afficher un catalogue de véhicules proposés à la vente, d’effectuer des recherches au sein de ce catalogue, de passer commande d’un véhicule, de choisir des options pour celui-ci avec un système de chariot virtuel. Les options incompatibles entre elles doivent également être gérées (par exemple "sièges sportifs" et "sièges en cuir" sont des options incompatibles). Il est également possible de revenir à un état précédent du chariot. Le système doit gérer les commandes. Il doit être capable de calculer les taxes en fonction du pays de livraison du véhicule. Il doit également gérer les commandes payées au comptant et celles assorties d’une demande de crédit. Il prend en compte les demandes de crédit. Le système gère les états de la commande : en cours, validée et livrée. Lors de la commande d’un véhicule, le système construit la liasse des documents nécessaires comme la demande d’immatriculation, le certificat de cession et le bon de commande. Ces documents sont disponibles au format PDF ou au format HTML. Le système permet également de solder les véhicules difficiles à vendre, à savoir ceux qui sont dans le stock depuis longtemps. Il permet également une gestion des clients, en particulier des sociétés possédant des filiales afin de leur proposer, par exemple, l’achat d’une flotte de véhicules. Lors de la visualisation du catalogue, il est possible de visualiser des animations associées à un véhicule. Le catalogue peut être présenté avec un ou trois véhicules par ligne. La recherche dans le catalogue peut s’effectuer à l’aide de mots clés et d’opérateurs logiques (et, ou). Il est possible d’accéder au système via une interface web.

![Alt text](image-4.png)


## Les patterns/patrons de création/construction

Les patterns de creation sont des patterns qui fournissent des mecanismes de creation d'objets qui augmentent la flexibilite et la reutilisabilite du code existant : on utilise l'abstraction du mecanisme de creation d'objets.

Les classes concretes sont encapsulees lors de l'utilisation de tels patterns, on favorise l'utilisation d'intefaces et de classes abstraites.

Le pattern Singleton est un pattern de creation. il permet de construire une classe possedant au maximum une seule instance. Le mecanisme qui gere l'acces a la classe est encapsule dans la classe elle-meme. Le client de la classe n'est pas au courant de l'existence du mecanisme.

## Les problemes liés à la creation d'objets

En C# la création d'objet se fait de la facon suivante :

objet = new Classe();
On peut parametrer la creation d'objet en utilisant des constructeurs, ou des methodes de creation.

public Document construitDocument(string typeDocument)
{
    Document document = null;
    if (typeDocument.equals("PDF"))
    {
        document = new DocumentPDF();
    }
    else if (typeDocument.equals("HTML")
    {
        document = new DocumentHTML();
    }
    return document;
}
Cet exemple temoigne de la complexite du parametrage du mecanisme de creation d'objet. Il est difficile de modifier le code pour ajouter un nouveau type de document.

## Les patterns de creation

### Abstract Factory

#### Definition: Fournit une interface pour la creation de familles d'objets lies ou dependants sans preciser leur classe concrete.

#### Contexte:

Le systeme de vente de vehicules gere des vehicules qui fonctionnent soit de maniere electrique soit avec de l'essence. La gestion de ce mecanisme sera gere par la l'objet Catalogue. L'objet Catalogue se charge alors de cree de tels objets (vehicules).

Pour chacun des prduits, nous disposons d'une classe abstraite, et sous-classe qui decrit la version electrique et la version essence.

Si l'objet Catalogue utilise les sous classes pour instancier les produits, on devra apporter des modifications a la classe catalogue lors de l'ajout de chaque nouveau produit.

Le pattern Abstract Factory resout cette problematique en introduisant une interface FabriqueVehicule qui contient la signature des methodes pour definir chaque produit. Le type de retour de ces methodes est constitué par l'une des classes abstraites de produit. L'objet Catalogue n'a alors pas besoin de connaitre les classes concretes des produits.

Une sous-classe d’implementation de FabriqueVehicule est introduite pour chaque famille de produit, à savoir les sous-classes FabriqueVehiculeEssence et FabriqueVehiculeElectrique. Une telle sous-classe implante les opérations de création du véhicule appropriée pour la famille à laquelle elle est associée.

L’objet prend alors pour paramètre une instance répondant à l’interface, c’est-à-dire soit une instance de FabriqueVehiculeElectrique , soit une instance de FabriqueVehiculeEssence . Avec une telle instance, le Catalogue peut créer et manipuler des véhicules sans devoir connaître les familles de véhicule et les classes concrètes d’instanciation correspondantes.

Schema UML:
![Alt text](image-5.png)

Structure generique du pattern:

![Alt text](image-6.png)

