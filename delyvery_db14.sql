-- MySQL dump 10.13  Distrib 8.0.28, for Win64 (x86_64)
--
-- Host: localhost    Database: delyvery_db14
-- ------------------------------------------------------
-- Server version	8.0.28

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `couriers`
--

DROP TABLE IF EXISTS `couriers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `couriers` (
  `idcouriers` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `telephon_number` varchar(15) NOT NULL,
  `iddelivery_services` int NOT NULL,
  PRIMARY KEY (`idcouriers`),
  KEY `iddelivery_services` (`iddelivery_services`),
  CONSTRAINT `couriers_ibfk_1` FOREIGN KEY (`iddelivery_services`) REFERENCES `delivery_services` (`iddelivery_services`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `couriers`
--

LOCK TABLES `couriers` WRITE;
/*!40000 ALTER TABLE `couriers` DISABLE KEYS */;
/*!40000 ALTER TABLE `couriers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `couriers_to_orders`
--

DROP TABLE IF EXISTS `couriers_to_orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `couriers_to_orders` (
  `idcouriers` int NOT NULL,
  `idorders` int NOT NULL,
  PRIMARY KEY (`idcouriers`,`idorders`),
  KEY `idorders` (`idorders`),
  CONSTRAINT `couriers_to_orders_ibfk_1` FOREIGN KEY (`idcouriers`) REFERENCES `couriers` (`idcouriers`) ON DELETE CASCADE,
  CONSTRAINT `couriers_to_orders_ibfk_2` FOREIGN KEY (`idorders`) REFERENCES `orders` (`idorders`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `couriers_to_orders`
--

LOCK TABLES `couriers_to_orders` WRITE;
/*!40000 ALTER TABLE `couriers_to_orders` DISABLE KEYS */;
/*!40000 ALTER TABLE `couriers_to_orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customers`
--

DROP TABLE IF EXISTS `customers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customers` (
  `idcustomers` int NOT NULL AUTO_INCREMENT,
  `address` varchar(1000) NOT NULL,
  `name` varchar(100) NOT NULL,
  `telephon_number` varchar(15) NOT NULL,
  PRIMARY KEY (`idcustomers`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customers`
--

LOCK TABLES `customers` WRITE;
/*!40000 ALTER TABLE `customers` DISABLE KEYS */;
INSERT INTO `customers` VALUES (1,'Волгоград, ул Павлова 4,кв 88','Сергей','89880100983'),(2,'Волгоград, ул Павлова 6,кв 65','Владислав','898885768594'),(3,'Волгоград, ул Хользунова 3 кв 55','Наталья','898885768475'),(4,'Волгоград, ул Богомолова 3 кв 23','Кирилл','898885766475'),(5,'Волгоград, ул Мясникова 3 кв 2','Андрей','898875874637'),(6,'Волгоград, ул проспект Маршала Жукова, 66 кв 3','Анастасия','89876567475'),(7,'Волгоград, ул Барнаульская, 7 кв 73','Евгения','895647283746'),(8,'Волгоград, ул Весëлая 1, кв 23','Сергей','89880100981'),(9,'Волгоград, ул Брестская 2,кв 1','Виктория','898473654672'),(10,'Волгоград, ул Анисовая 2, кв 11','Анастасия','891783746565');
/*!40000 ALTER TABLE `customers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `delivery_services`
--

DROP TABLE IF EXISTS `delivery_services`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `delivery_services` (
  `iddelivery_services` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  PRIMARY KEY (`iddelivery_services`),
  UNIQUE KEY `name_UNIQUE` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `delivery_services`
--

LOCK TABLES `delivery_services` WRITE;
/*!40000 ALTER TABLE `delivery_services` DISABLE KEYS */;
/*!40000 ALTER TABLE `delivery_services` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `firms`
--

DROP TABLE IF EXISTS `firms`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `firms` (
  `idfirms` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  PRIMARY KEY (`idfirms`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `firms`
--

LOCK TABLES `firms` WRITE;
/*!40000 ALTER TABLE `firms` DISABLE KEYS */;
INSERT INTO `firms` VALUES (1,'Простоквашино'),(2,'Demix'),(3,'Конфил'),(4,'Coca cola'),(5,'Мироторг'),(6,'Увелка'),(7,'Адидас'),(8,'Хлебный дом'),(9,'Макдональдс'),(10,'Моя цена');
/*!40000 ALTER TABLE `firms` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `groceries`
--

DROP TABLE IF EXISTS `groceries`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `groceries` (
  `idgroceries` int NOT NULL AUTO_INCREMENT,
  `price` int NOT NULL,
  `shelf_life` date DEFAULT NULL,
  `name` varchar(100) NOT NULL,
  `idtypes` int NOT NULL,
  `idfirms` int NOT NULL,
  `idmarkets` int NOT NULL,
  PRIMARY KEY (`idgroceries`),
  KEY `idtypes` (`idtypes`),
  KEY `idfirms` (`idfirms`),
  KEY `idmarkets` (`idmarkets`),
  CONSTRAINT `groceries_ibfk_1` FOREIGN KEY (`idtypes`) REFERENCES `types` (`idtypes`) ON DELETE CASCADE,
  CONSTRAINT `groceries_ibfk_2` FOREIGN KEY (`idfirms`) REFERENCES `firms` (`idfirms`) ON DELETE CASCADE,
  CONSTRAINT `groceries_ibfk_3` FOREIGN KEY (`idmarkets`) REFERENCES `markets` (`idmarkets`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `groceries`
--

LOCK TABLES `groceries` WRITE;
/*!40000 ALTER TABLE `groceries` DISABLE KEYS */;
INSERT INTO `groceries` VALUES (1,100,'2022-06-12','Молоко',1,1,1),(2,1200,NULL,'Рюкзак',2,2,2),(3,150,'2022-07-18','Конфеты Каракум',3,3,3),(4,120,'2022-05-18','Лимонад Фанта',4,4,4),(5,170,'2022-09-18','Беларусские котлеты',5,5,5),(6,70,'2024-09-18','Гречка',6,6,6),(7,2000,NULL,'Кросовки',7,7,7),(8,39,'2022-05-18','Батон нарезной',8,8,8),(9,79,'2022-04-13','Гамбургер',9,9,9),(10,300,'2022-05-18','Пармизан',10,10,10);
/*!40000 ALTER TABLE `groceries` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `markets`
--

DROP TABLE IF EXISTS `markets`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `markets` (
  `idmarkets` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `address` varchar(1000) NOT NULL,
  PRIMARY KEY (`idmarkets`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `markets`
--

LOCK TABLES `markets` WRITE;
/*!40000 ALTER TABLE `markets` DISABLE KEYS */;
INSERT INTO `markets` VALUES (1,'Перекресток','Волгоград ул Павлова 1'),(2,'Спортивные товары','Волгоград ул Павлова 2'),(3,'Конфил','Волгоград ул Хользунова 1'),(4,'Ман','Волгоград ул Мясникова 12'),(5,'Магнит','Волгоград ул Николая отрады 1а'),(6,'Пятерочка','Волгоград ул Кропоткина 2'),(7,'Радеж','Волгоград пр Ленина 12'),(8,'Светофор','Волгограл пр Металлургов 7'),(9,'Макдональдс','Волгоград ул Мира 8'),(10,'Магнит у дома','Волгоград ул Багунская 4');
/*!40000 ALTER TABLE `markets` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `operators`
--

DROP TABLE IF EXISTS `operators`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `operators` (
  `idoperators` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `telephon_number` varchar(15) NOT NULL,
  PRIMARY KEY (`idoperators`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `operators`
--

LOCK TABLES `operators` WRITE;
/*!40000 ALTER TABLE `operators` DISABLE KEYS */;
INSERT INTO `operators` VALUES (1,'Максим','898823456983'),(2,'Виктор','89834568594'),(3,'Алена','891234567475'),(4,'Альбина','8988823456775'),(5,'Матвей','893457654637'),(6,'Антон','89765432175'),(7,'Николай','895999876546'),(8,'Никита','898987654631'),(9,'Виктория','893456789098'),(10,'Артем','891987654673');
/*!40000 ALTER TABLE `operators` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_pickers`
--

DROP TABLE IF EXISTS `order_pickers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `order_pickers` (
  `idorder_pickers` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `iddelivery_services` int NOT NULL,
  PRIMARY KEY (`idorder_pickers`),
  KEY `iddelivery_services` (`iddelivery_services`),
  CONSTRAINT `order_pickers_ibfk_1` FOREIGN KEY (`iddelivery_services`) REFERENCES `delivery_services` (`iddelivery_services`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_pickers`
--

LOCK TABLES `order_pickers` WRITE;
/*!40000 ALTER TABLE `order_pickers` DISABLE KEYS */;
/*!40000 ALTER TABLE `order_pickers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_pickers_to_orders`
--

DROP TABLE IF EXISTS `order_pickers_to_orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `order_pickers_to_orders` (
  `idorder_pickers` int NOT NULL,
  `idorders` int NOT NULL,
  PRIMARY KEY (`idorder_pickers`,`idorders`),
  KEY `idorders` (`idorders`),
  CONSTRAINT `order_pickers_to_orders_ibfk_1` FOREIGN KEY (`idorder_pickers`) REFERENCES `order_pickers` (`idorder_pickers`) ON DELETE CASCADE,
  CONSTRAINT `order_pickers_to_orders_ibfk_2` FOREIGN KEY (`idorders`) REFERENCES `orders` (`idorders`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_pickers_to_orders`
--

LOCK TABLES `order_pickers_to_orders` WRITE;
/*!40000 ALTER TABLE `order_pickers_to_orders` DISABLE KEYS */;
/*!40000 ALTER TABLE `order_pickers_to_orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orders` (
  `idorders` int NOT NULL AUTO_INCREMENT,
  `date_time_of_order` date NOT NULL,
  `time_to_start_worling_on_the_order` time NOT NULL,
  `expected_time_of_arrival` time NOT NULL,
  `idcustomers` int NOT NULL,
  `idoperators` int NOT NULL,
  PRIMARY KEY (`idorders`),
  KEY `idcustomers` (`idcustomers`),
  KEY `idoperators` (`idoperators`),
  CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`idcustomers`) REFERENCES `customers` (`idcustomers`) ON DELETE CASCADE,
  CONSTRAINT `orders_ibfk_2` FOREIGN KEY (`idoperators`) REFERENCES `operators` (`idoperators`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders`
--

LOCK TABLES `orders` WRITE;
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
INSERT INTO `orders` VALUES (1,'2022-04-12','17:55:30','18:30:00',1,1),(2,'2022-04-12','17:58:31','18:40:00',2,2),(3,'2022-04-12','18:03:31','18:45:00',3,3),(4,'2022-04-12','18:10:31','18:51:00',4,3),(5,'2022-04-12','18:15:31','18:59:00',5,3),(6,'2022-04-12','18:28:31','19:02:00',6,3),(7,'2022-04-12','19:03:31','19:40:00',7,4),(8,'2022-04-12','19:05:31','19:25:00',8,5),(9,'2022-04-12','19:30:31','19:55:00',9,6),(10,'2022-04-12','19:32:31','19:59:00',10,7);
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orders_to_groceries`
--

DROP TABLE IF EXISTS `orders_to_groceries`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orders_to_groceries` (
  `idorders` int NOT NULL,
  `idgroceries` int NOT NULL,
  PRIMARY KEY (`idorders`,`idgroceries`),
  KEY `idgroceries` (`idgroceries`),
  CONSTRAINT `orders_to_groceries_ibfk_1` FOREIGN KEY (`idorders`) REFERENCES `orders` (`idorders`) ON DELETE CASCADE,
  CONSTRAINT `orders_to_groceries_ibfk_2` FOREIGN KEY (`idgroceries`) REFERENCES `groceries` (`idgroceries`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders_to_groceries`
--

LOCK TABLES `orders_to_groceries` WRITE;
/*!40000 ALTER TABLE `orders_to_groceries` DISABLE KEYS */;
INSERT INTO `orders_to_groceries` VALUES (1,1),(1,2),(1,3),(1,4),(2,5),(3,6),(4,7),(5,8),(6,9),(7,10);
/*!40000 ALTER TABLE `orders_to_groceries` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reviews`
--

DROP TABLE IF EXISTS `reviews`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reviews` (
  `idreviews` int NOT NULL AUTO_INCREMENT,
  `text_reviews` varchar(100) DEFAULT NULL,
  `raiting` int DEFAULT NULL,
  `date_time` datetime DEFAULT NULL,
  `idoperators` int DEFAULT NULL,
  `idorder_pickers` int DEFAULT NULL,
  `iddelivery_services` int DEFAULT NULL,
  `idcustomers` int DEFAULT NULL,
  `idcouriers` int DEFAULT NULL,
  PRIMARY KEY (`idreviews`),
  KEY `idoperators` (`idoperators`),
  KEY `idorder_pickers` (`idorder_pickers`),
  KEY `iddelivery_services` (`iddelivery_services`),
  KEY `idcustomers` (`idcustomers`),
  KEY `idcouriers` (`idcouriers`),
  CONSTRAINT `reviews_ibfk_1` FOREIGN KEY (`idoperators`) REFERENCES `operators` (`idoperators`) ON DELETE CASCADE,
  CONSTRAINT `reviews_ibfk_2` FOREIGN KEY (`idorder_pickers`) REFERENCES `order_pickers` (`idorder_pickers`) ON DELETE CASCADE,
  CONSTRAINT `reviews_ibfk_3` FOREIGN KEY (`iddelivery_services`) REFERENCES `delivery_services` (`iddelivery_services`) ON DELETE CASCADE,
  CONSTRAINT `reviews_ibfk_4` FOREIGN KEY (`idcustomers`) REFERENCES `customers` (`idcustomers`) ON DELETE CASCADE,
  CONSTRAINT `reviews_ibfk_5` FOREIGN KEY (`idcouriers`) REFERENCES `couriers` (`idcouriers`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reviews`
--

LOCK TABLES `reviews` WRITE;
/*!40000 ALTER TABLE `reviews` DISABLE KEYS */;
INSERT INTO `reviews` VALUES (4,'Оператор быстро создал заявку',5,'2022-04-12 18:56:10',1,NULL,NULL,1,NULL),(10,'Оператор быстро создал заявку',5,'2022-04-12 20:20:00',4,NULL,NULL,6,NULL);
/*!40000 ALTER TABLE `reviews` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `types`
--

DROP TABLE IF EXISTS `types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `types` (
  `idtypes` int NOT NULL AUTO_INCREMENT,
  `text_types` varchar(1000) NOT NULL,
  PRIMARY KEY (`idtypes`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `types`
--

LOCK TABLES `types` WRITE;
/*!40000 ALTER TABLE `types` DISABLE KEYS */;
INSERT INTO `types` VALUES (1,'Молочная продукция'),(2,'Спортивные товары'),(3,'Сладости'),(4,'Напитки'),(5,'Мясная продукция'),(6,'Крупы'),(7,'Одежда'),(8,'Хлебобулочные изделия'),(9,'Фастфуд'),(10,'Сырная продукция');
/*!40000 ALTER TABLE `types` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-04-08 13:26:50
