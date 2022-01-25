-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 05-06-2020 a las 22:18:51
-- Versión del servidor: 10.4.6-MariaDB
-- Versión de PHP: 7.1.32

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `db_servidor`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `apellidos`
--

CREATE TABLE `apellidos` (
  `id_apellido` int(11) NOT NULL,
  `apellido` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `apellidos`
--

INSERT INTO `apellidos` (`id_apellido`, `apellido`) VALUES
(1, 'Herrero'),
(2, 'Gonzalez'),
(3, 'Rodrigez'),
(4, 'Fernandez'),
(5, 'Lopez'),
(6, 'Martinez'),
(7, 'Sanchez'),
(8, 'Perez'),
(9, 'Gomez'),
(10, 'Martin'),
(11, 'Ortiz'),
(12, 'Vigara'),
(13, 'Sagrado'),
(14, 'Rivera');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `caracteristicas`
--

CREATE TABLE `caracteristicas` (
  `id_caracteristicas` varchar(10) NOT NULL,
  `Fuerza` int(11) DEFAULT NULL,
  `Constitucion` int(11) DEFAULT NULL,
  `Tamano` int(11) DEFAULT NULL,
  `Destreza` int(11) DEFAULT NULL,
  `Apariencia` int(11) DEFAULT NULL,
  `Inteligencia` int(11) DEFAULT NULL,
  `Poder` int(11) DEFAULT NULL,
  `Educacion` int(11) DEFAULT NULL,
  `Idea` int(11) DEFAULT NULL,
  `Suerte` int(11) DEFAULT NULL,
  `Conocimiento` int(11) DEFAULT NULL,
  `Puntos_Cordura_Max` int(11) DEFAULT NULL,
  `Puntos_Vida_Max` int(11) DEFAULT NULL,
  `Puntos_Magia_Max` int(11) DEFAULT NULL,
  `Puntos_Vida_Actual` int(11) DEFAULT NULL,
  `Puntos_Magia_Actual` int(11) DEFAULT NULL,
  `Puntos_Cordura_Actual` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cuentas_usuario`
--

CREATE TABLE `cuentas_usuario` (
  `id` int(11) NOT NULL,
  `username` varchar(16) NOT NULL,
  `hash` varchar(100) DEFAULT NULL,
  `salt` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `investigador`
--

CREATE TABLE `investigador` (
  `NombreCompleto` varchar(50) NOT NULL,
  `Profesion` varchar(50) NOT NULL,
  `Lugar_Nacimiento` varchar(50) NOT NULL,
  `id_caracteristicas` varchar(10) NOT NULL,
  `id_trastornos` varchar(10) NOT NULL,
  `id_datos` varchar(10) NOT NULL,
  `Sexo` enum('Hombre','Mujer') DEFAULT NULL,
  `Edad` int(11) DEFAULT NULL,
  `nombre_completo` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `lugarnacimiento`
--

CREATE TABLE `lugarnacimiento` (
  `id_lugarnac` int(11) NOT NULL,
  `lugarnac` varchar(50) DEFAULT NULL,
  `idlugar_nac` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `lugarnacimiento`
--

INSERT INTO `lugarnacimiento` (`id_lugarnac`, `lugarnac`, `idlugar_nac`) VALUES
(1, 'Madrid , España', 0),
(2, 'Bilbao , España', 0),
(3, 'Gibraltar , España', 0),
(4, 'Barcelona , España', 0),
(5, 'Toledo , España', 0),
(6, 'Sevilla , España', 0),
(7, 'Murcia , España', 0),
(8, 'Ciudad Real , España', 0),
(9, 'Badajoz , España', 0),
(10, 'Valladolid , España', 0),
(11, 'Zaragoza , España', 0),
(12, 'Palma , España', 0),
(13, 'Granada , España', 0),
(14, 'Salamanca , España', 0),
(15, 'Oviedo , España', 0),
(16, 'Cuenca , España', 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `nombres`
--

CREATE TABLE `nombres` (
  `id_nombre` int(11) NOT NULL,
  `nombre` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `nombres`
--

INSERT INTO `nombres` (`id_nombre`, `nombre`) VALUES
(1, 'Pedro'),
(2, 'Gabriel'),
(3, 'Miguel'),
(4, 'Maroto'),
(5, 'Daniel'),
(6, 'Juan'),
(7, 'Jose'),
(8, 'Andres'),
(9, 'Angel'),
(10, 'Hernesto'),
(11, 'Antonio'),
(12, 'Augusto'),
(13, 'Carlos'),
(14, 'Alfonso');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `objetos`
--

CREATE TABLE `objetos` (
  `id_objeto` varchar(10) NOT NULL,
  `Descripcion` varchar(50) DEFAULT NULL,
  `Coste` varchar(20) DEFAULT NULL,
  `Valor` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `objetos`
--

INSERT INTO `objetos` (`id_objeto`, `Descripcion`, `Coste`, `Valor`) VALUES
('1', 'Pistola', '10', '40'),
('10', 'Granada', '20', '10'),
('11', 'Necronomicon', '1000', '1000'),
('12', 'Biblia', '100', '100'),
('13', 'Documentos', '5', '5'),
('14', 'Muñeco Bodo', '10', '20'),
('15', 'Lagrimas de Murcielago', '15', '9'),
('16', 'Sangre de Cerdo', '3', '2'),
('17', 'Reloj de Mano', '35', '50'),
('18', 'Monoculo', '12', '12'),
('2', 'Collar de Perlas', '70', '35'),
('3', 'Palanca', '20', '10'),
('4', 'Tenedor', '1', '3'),
('5', 'Patata', '3', '2'),
('6', 'Coca Cola', '1', '2'),
('7', 'Baston Espada', '25', '30'),
('8', 'Espada Antigua', '200', '100'),
('9', 'Rifle', '50', '50');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `profesiones`
--

CREATE TABLE `profesiones` (
  `id_profesion` int(11) NOT NULL,
  `profesion` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `profesiones`
--

INSERT INTO `profesiones` (`id_profesion`, `profesion`) VALUES
(1, 'Psicologo'),
(2, 'Aventurero'),
(3, 'Policia'),
(4, 'Medico'),
(5, 'Obrero'),
(6, 'Granjero'),
(7, 'Mercenario'),
(8, 'Ocultista'),
(9, 'Parapsicologo'),
(10, 'Espia'),
(11, 'Ladron'),
(12, 'Profesor');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `trastornos`
--

CREATE TABLE `trastornos` (
  `id_trastornos` varchar(10) NOT NULL,
  `trastorno_1` tinyint(1) DEFAULT NULL,
  `trastorno_2` tinyint(1) DEFAULT NULL,
  `trastorno_3` tinyint(1) DEFAULT NULL,
  `trastorno_4` tinyint(1) DEFAULT NULL,
  `trastorno_5` tinyint(1) DEFAULT NULL,
  `trastorno_6` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `apellidos`
--
ALTER TABLE `apellidos`
  ADD PRIMARY KEY (`id_apellido`);

--
-- Indices de la tabla `caracteristicas`
--
ALTER TABLE `caracteristicas`
  ADD PRIMARY KEY (`id_caracteristicas`);

--
-- Indices de la tabla `cuentas_usuario`
--
ALTER TABLE `cuentas_usuario`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- Indices de la tabla `investigador`
--
ALTER TABLE `investigador`
  ADD PRIMARY KEY (`NombreCompleto`),
  ADD KEY `id_trastornos` (`id_trastornos`),
  ADD KEY `id_caracteristicas` (`id_caracteristicas`);

--
-- Indices de la tabla `lugarnacimiento`
--
ALTER TABLE `lugarnacimiento`
  ADD PRIMARY KEY (`id_lugarnac`);

--
-- Indices de la tabla `nombres`
--
ALTER TABLE `nombres`
  ADD PRIMARY KEY (`id_nombre`);

--
-- Indices de la tabla `objetos`
--
ALTER TABLE `objetos`
  ADD PRIMARY KEY (`id_objeto`);

--
-- Indices de la tabla `profesiones`
--
ALTER TABLE `profesiones`
  ADD PRIMARY KEY (`id_profesion`);

--
-- Indices de la tabla `trastornos`
--
ALTER TABLE `trastornos`
  ADD PRIMARY KEY (`id_trastornos`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `cuentas_usuario`
--
ALTER TABLE `cuentas_usuario`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `investigador`
--
ALTER TABLE `investigador`
  ADD CONSTRAINT `investigador_ibfk_1` FOREIGN KEY (`id_trastornos`) REFERENCES `trastornos` (`id_trastornos`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `investigador_ibfk_2` FOREIGN KEY (`id_caracteristicas`) REFERENCES `caracteristicas` (`id_caracteristicas`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
