-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le :  lun. 13 jan. 2020 à 14:34
-- Version du serveur :  5.7.24
-- Version de PHP :  7.2.14

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `mydb`
--

-- --------------------------------------------------------

--
-- Structure de la table `departement`
--

DROP TABLE IF EXISTS `departement`;
CREATE TABLE IF NOT EXISTS `departement` (
  `idDepartement` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(45) NOT NULL,
  PRIMARY KEY (`idDepartement`)
) ENGINE=InnoDB AUTO_INCREMENT=57 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `departement`
--

INSERT INTO `departement` (`idDepartement`, `nom`) VALUES
(35, 'Ille-et-Vilaine'),
(44, 'Loire-Atlantique'),
(56, 'Morbihan');

-- --------------------------------------------------------

--
-- Structure de la table `espece`
--

DROP TABLE IF EXISTS `espece`;
CREATE TABLE IF NOT EXISTS `espece` (
  `idEspece` int(11) NOT NULL,
  `nomEspece` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idEspece`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `etude`
--

DROP TABLE IF EXISTS `etude`;
CREATE TABLE IF NOT EXISTS `etude` (
  `idEtude` int(11) NOT NULL AUTO_INCREMENT,
  `nomEtude` varchar(245) NOT NULL,
  `dateEtude` date NOT NULL,
  `nbPersonne` int(11) NOT NULL,
  `Personne_idPersonne` int(11) NOT NULL,
  PRIMARY KEY (`idEtude`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `etude`
--

INSERT INTO `etude` (`idEtude`, `nomEtude`, `dateEtude`, `nbPersonne`, `Personne_idPersonne`) VALUES
(1, 'Etude 1', '2019-12-17', 12, 1),
(2, 'ETUDE DES BATRACIENS', '2020-01-01', 5, 3);

-- --------------------------------------------------------

--
-- Structure de la table `personne`
--

DROP TABLE IF EXISTS `personne`;
CREATE TABLE IF NOT EXISTS `personne` (
  `idpersonne` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(45) DEFAULT NULL,
  `prenom` varchar(45) DEFAULT NULL,
  `Etude_idEtude` int(11) NOT NULL,
  PRIMARY KEY (`idpersonne`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `personne`
--

INSERT INTO `personne` (`idpersonne`, `nom`, `prenom`, `Etude_idEtude`) VALUES
(1, 'Manceau', 'Etienne', 1),
(2, 'ZARANSKI', 'Theo', 3),
(3, 'HAMON ', 'Jules', 2);

-- --------------------------------------------------------

--
-- Structure de la table `personne_has_etude`
--

DROP TABLE IF EXISTS `personne_has_etude`;
CREATE TABLE IF NOT EXISTS `personne_has_etude` (
  `idPersonne` int(11) NOT NULL,
  `idEtude` int(11) NOT NULL,
  PRIMARY KEY (`idPersonne`,`idEtude`),
  KEY `idPersonne` (`idPersonne`,`idEtude`),
  KEY `fk_Personne_Etude` (`idEtude`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `personne_has_etude`
--

INSERT INTO `personne_has_etude` (`idPersonne`, `idEtude`) VALUES
(1, 1);

-- --------------------------------------------------------

--
-- Structure de la table `plage`
--

DROP TABLE IF EXISTS `plage`;
CREATE TABLE IF NOT EXISTS `plage` (
  `idPlage` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(45) DEFAULT NULL,
  `Ville_idVille` int(11) NOT NULL,
  `superficie` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idPlage`),
  KEY `fk_Plage_Ville_idx` (`Ville_idVille`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `plage`
--

INSERT INTO `plage` (`idPlage`, `nom`, `Ville_idVille`, `superficie`) VALUES
(5, 'LA BAULE', 1, '2300'),
(6, 'EZIBFVZIVB', 2, '350'),
(7, 'TEST2', 3, '415'),
(8, 'TEST3', 4, '500');

-- --------------------------------------------------------

--
-- Structure de la table `ville`
--

DROP TABLE IF EXISTS `ville`;
CREATE TABLE IF NOT EXISTS `ville` (
  `idVille` int(11) NOT NULL AUTO_INCREMENT,
  `nomVille` varchar(45) DEFAULT NULL,
  `nomSpecialiste` varchar(45) DEFAULT NULL,
  `Departement_idDepartement` int(11) NOT NULL,
  PRIMARY KEY (`idVille`),
  KEY `fk_Departement_Ville` (`Departement_idDepartement`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `ville`
--

INSERT INTO `ville` (`idVille`, `nomVille`, `nomSpecialiste`, `Departement_idDepartement`) VALUES
(1, 'La Baule', 'Jeremy', 44),
(2, 'Quiberon', 'Johan', 56),
(3, 'Dinard', 'Sacha', 35),
(4, 'Lancieux', 'Camille', 35);

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `personne_has_etude`
--
ALTER TABLE `personne_has_etude`
  ADD CONSTRAINT `fk_Etude_Personne` FOREIGN KEY (`idPersonne`) REFERENCES `personne` (`idpersonne`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Personne_Etude` FOREIGN KEY (`idEtude`) REFERENCES `etude` (`idEtude`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Contraintes pour la table `plage`
--
ALTER TABLE `plage`
  ADD CONSTRAINT `fk_Plage_Ville` FOREIGN KEY (`Ville_idVille`) REFERENCES `ville` (`idVille`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Contraintes pour la table `ville`
--
ALTER TABLE `ville`
  ADD CONSTRAINT `fk_Departement_Ville` FOREIGN KEY (`Departement_idDepartement`) REFERENCES `departement` (`idDepartement`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
