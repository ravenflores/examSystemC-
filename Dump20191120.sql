CREATE DATABASE  IF NOT EXISTS `exam_system1` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */;
USE `exam_system1`;
-- MySQL dump 10.13  Distrib 8.0.12, for Win64 (x86_64)
--
-- Host: localhost    Database: exam_system1
-- ------------------------------------------------------
-- Server version	8.0.12

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `accounts`
--

DROP TABLE IF EXISTS `accounts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `accounts` (
  `userid` int(200) NOT NULL,
  `userpass` varchar(30) DEFAULT NULL,
  `firstname` varchar(45) DEFAULT NULL,
  `middlename` varchar(45) DEFAULT NULL,
  `lastname` varchar(45) DEFAULT NULL,
  `position` varchar(10) DEFAULT NULL,
  `grade` varchar(45) DEFAULT NULL,
  `section` varchar(45) DEFAULT NULL,
  `picture` varchar(150) DEFAULT NULL,
  PRIMARY KEY (`userid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `accounts`
--

LOCK TABLES `accounts` WRITE;
/*!40000 ALTER TABLE `accounts` DISABLE KEYS */;
INSERT INTO `accounts` VALUES (100,'3yaSUpbHYd8QicraEJQE3w==','noel','a','nuez','admin',NULL,NULL,NULL),(101,'U255imtP8W+H6Pvr3jR/UA==','john paulo','roque','dela umrbia','teacher',NULL,NULL,NULL),(150,'JtxRt+nA1Gf46Qz1NzR4qA==','pepepappad','wadadwadwaw','wdwadwa','admin',NULL,NULL,NULL),(151,'PB/127XaGRRaD+94A/1ZRw==','asdwdw','asdwad','asdwd','admin',NULL,NULL,NULL),(200,'Xs6tr7qfffBdJFBJ2dLeTg==','philip','j','vistal','teacher',NULL,NULL,NULL),(203,'3vneUo6qpaZJ6Pdgb+K0Yw==','john paulo','r','delaumbria','teacher',NULL,NULL,NULL),(205,'7/uemOi6bu1acDc5mH+lbg==','asdasdas','asdasda','asdasdasda','student','9','queen of love',NULL),(219,'3yC410r4Sp+8KH0gxX84uQ==','pawlo','roque','dela umbs','teacher',NULL,NULL,NULL),(300,'ut13z7qaIqpHAW6VtwHpQA==','rhianna','a','hicap','student','9','queen of love',NULL),(301,'yw7IZPeeU6u5maE16hotxg==','jana louise','c','mercado','student','9','queen of love',NULL),(302,'23qj4bxNqW+XphA7r0VQmQ==','asdasd','asdasd','dasdas','student','9','queen of love',NULL),(1023,'0co6r1K0Gs1o67O/aQeb0Q==','papa','pepe','pepe','admin',NULL,NULL,NULL),(2019100,'tRLlRizThs6Jc+7KGrKjXA==','admin','admn','admin','admin',NULL,NULL,NULL),(2015001940,'BpZNzprdscXLXW49mDj3Mw==','Chan','gfs','Heo','Student','6','kamatis',NULL),(2015001990,'Xsgp3r5UsZpfeNmmW5AKOQ==','Subin','gds','Jung','Student','6','kamatis',NULL),(2015004840,'Xsgp3r5UsZpfeNmmW5AKOQ==','Ma. Venus','Callo','Ngalot','Student','6','kamatis',NULL),(2015009380,'PwiOvtoDUTvnHTTSFCkZhg==','Sejun','zg','Lim','Student','6','kamatis',NULL);
/*!40000 ALTER TABLE `accounts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `class`
--

DROP TABLE IF EXISTS `class`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `class` (
  `grade` int(11) DEFAULT NULL,
  `section` varchar(30) DEFAULT NULL,
  UNIQUE KEY `section_UNIQUE` (`section`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `class`
--

LOCK TABLES `class` WRITE;
/*!40000 ALTER TABLE `class` DISABLE KEYS */;
INSERT INTO `class` VALUES (7,'queen of heaven'),(8,'queen of prophets'),(9,'queen of love'),(8,'kamote');
/*!40000 ALTER TABLE `class` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `classes`
--

DROP TABLE IF EXISTS `classes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `classes` (
  `classid` int(11) NOT NULL,
  `classname` varchar(45) DEFAULT NULL,
  `userid` int(20) DEFAULT NULL,
  PRIMARY KEY (`classid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `classes`
--

LOCK TABLES `classes` WRITE;
/*!40000 ALTER TABLE `classes` DISABLE KEYS */;
/*!40000 ALTER TABLE `classes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `exam_parts`
--

DROP TABLE IF EXISTS `exam_parts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `exam_parts` (
  `teacher_id` int(11) DEFAULT NULL,
  `exam_id` int(11) NOT NULL,
  `exam_name` varchar(50) DEFAULT NULL,
  `part_no` int(11) DEFAULT NULL,
  `items` int(11) DEFAULT NULL,
  `exam_type` varchar(35) DEFAULT NULL,
  `points_per_item` int(11) DEFAULT NULL,
  `instructions` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `exam_parts`
--

LOCK TABLES `exam_parts` WRITE;
/*!40000 ALTER TABLE `exam_parts` DISABLE KEYS */;
INSERT INTO `exam_parts` VALUES (102,1,'PT',1,1,'Multiple Choice',2,NULL),(102,1,'PT',2,2,'Identification',2,NULL),(102,1,'PT',3,3,'Multiple Choice',1,NULL),(102,1,'PT',4,1,'Identification',3,NULL),(102,2,'demo testing',1,5,'true or false',4,NULL),(102,2,'demo testing',2,7,'Identification',1,NULL),(100,1,'periodical test  - math',1,2,'Multiple Choice',3,NULL),(100,1,'periodical test  - math',2,1,'Identification',2,NULL),(100,1,'periodical test  - math',3,1,'true or false',4,NULL),(100,1,'periodical test  - math',4,1,'Multiple Choice',1,NULL),(100,2,'',1,3,'Identification',4,NULL),(100,2,'',2,2,'Multiple Choice',2,NULL),(100,2,'',3,6,'true or false',3,NULL),(100,2,'',4,5,'Identification',4,NULL),(100,3,'ASA',1,4,'Photo Guest',4,NULL),(100,3,'ASA',2,2,'Photo Guest',2,NULL),(100,4,'AD',1,30,'Photo Guest',2,NULL),(100,4,'AD',2,20,'Photo Guest',3,NULL);
/*!40000 ALTER TABLE `exam_parts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `exams`
--

DROP TABLE IF EXISTS `exams`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `exams` (
  `teacher_id` int(11) DEFAULT NULL,
  `exam_id` int(11) DEFAULT NULL,
  `exam_name` varchar(75) DEFAULT NULL,
  `exam_date` date DEFAULT NULL,
  `parts` int(11) DEFAULT NULL,
  `status` varchar(1) DEFAULT NULL,
  `grade` int(11) DEFAULT NULL,
  `section` varchar(45) DEFAULT NULL,
  `duration_hrs` int(11) DEFAULT NULL,
  `duration_mins` int(11) DEFAULT NULL,
  `no_of_exams` int(11) DEFAULT NULL,
  `subject` varchar(45) DEFAULT NULL,
  KEY `user` (`teacher_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `exams`
--

LOCK TABLES `exams` WRITE;
/*!40000 ALTER TABLE `exams` DISABLE KEYS */;
INSERT INTO `exams` VALUES (102,1,'PT','2018-09-17',4,'1',6,'sampaguita',1,3,12,NULL),(102,2,'demo testing','2018-09-17',2,'1',6,'sampaguita',0,30,27,NULL),(100,1,'periodical test  - math','2018-09-18',4,'1',6,'rose',0,5,13,NULL),(100,2,'','2018-09-18',4,'1',4,'rose',0,5,54,NULL),(100,3,'ASA','2018-09-29',2,'0',6,'sampaguita',1,2,20,NULL),(100,4,'AD','2018-09-29',2,'0',6,'sampaguita',1,0,120,NULL);
/*!40000 ALTER TABLE `exams` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `images`
--

DROP TABLE IF EXISTS `images`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `images` (
  `imageid` int(11) DEFAULT NULL,
  `image` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `answer` varchar(300) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `images`
--

LOCK TABLES `images` WRITE;
/*!40000 ALTER TABLE `images` DISABLE KEYS */;
/*!40000 ALTER TABLE `images` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `questions`
--

DROP TABLE IF EXISTS `questions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `questions` (
  `teacher_id` int(11) DEFAULT NULL,
  `exam_id` int(11) NOT NULL,
  `part_no` int(11) DEFAULT NULL,
  `item_no` int(11) DEFAULT NULL,
  `question` varchar(190) DEFAULT NULL,
  `answer` varchar(50) DEFAULT NULL,
  `choice_1` varchar(50) DEFAULT NULL,
  `choice_2` varchar(50) DEFAULT NULL,
  `choice_3` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `questions`
--

LOCK TABLES `questions` WRITE;
/*!40000 ALTER TABLE `questions` DISABLE KEYS */;
/*!40000 ALTER TABLE `questions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `student_records`
--

DROP TABLE IF EXISTS `student_records`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `student_records` (
  `col_teacher_id` int(11) DEFAULT NULL,
  `col_exam_id` int(11) DEFAULT NULL,
  `col_exam_name` varchar(45) DEFAULT NULL,
  `stud_id` varchar(11) DEFAULT NULL,
  `part_no` int(2) DEFAULT NULL,
  `item_no` int(2) DEFAULT NULL,
  `answer` varchar(45) DEFAULT NULL,
  `score` int(11) DEFAULT NULL,
  `essay_flag` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `student_records`
--

LOCK TABLES `student_records` WRITE;
/*!40000 ALTER TABLE `student_records` DISABLE KEYS */;
INSERT INTO `student_records` VALUES (200,1,'periodical test 1st grading','300',1,2,'a',1,NULL),(200,1,'periodical test 1st grading','300',1,4,'c',1,NULL),(200,1,'periodical test 1st grading','300',1,1,'electronics data message',1,NULL),(200,1,'periodical test 1st grading','300',1,5,'e',1,NULL),(200,1,'periodical test 1st grading','300',1,3,'b',1,NULL),(200,1,'periodical test 1st grading','300',2,4,'d',1,NULL),(200,1,'periodical test 1st grading','300',2,1,'a',1,NULL),(200,1,'periodical test 1st grading','300',2,5,'e',1,NULL),(200,1,'periodical test 1st grading','300',2,3,'c',1,NULL),(200,1,'periodical test 1st grading','300',2,2,'b',1,NULL),(200,1,'periodical test 1st grading','300',3,2,'',0,NULL),(200,1,'periodical test 1st grading','300',3,2,'',0,NULL),(200,1,'periodical test 1st grading','300',3,3,'',0,NULL),(200,1,'periodical test 1st grading','300',3,3,'',0,NULL),(200,1,'periodical test 1st grading','300',3,1,'',0,NULL),(200,1,'periodical test 1st grading','300',3,1,'',0,NULL),(200,1,'periodical test 1st grading','300',3,1,'',0,NULL),(200,1,'periodical test 1st grading','300',4,3,'b',0,NULL),(200,1,'periodical test 1st grading','300',4,4,'b',0,NULL),(200,1,'periodical test 1st grading','300',4,5,'b',0,NULL),(200,1,'periodical test 1st grading','300',4,1,'b',0,NULL),(200,1,'periodical test 1st grading','300',4,2,'b',0,NULL),(200,1,'periodical test 1st grading','300',5,3,'',0,NULL),(200,1,'periodical test 1st grading','300',5,1,'',0,NULL),(200,1,'periodical test 1st grading','300',5,2,'',0,NULL),(200,3,'identification','300',1,3,'i',1,NULL),(200,3,'identification','300',1,1,'o',1,NULL),(200,3,'identification','300',1,2,'i',1,NULL),(200,2,'Essay','300',1,3,'    essay number 3 asdf\r\nasdsf\r\nsadfda\r\nfd\r\nd',3,1),(200,2,'Essay','300',1,1,'    essay 1sfdsf\r\nsdfsfsfsf\r\nsfsfdsafs\r\nf',1,1),(200,2,'Essay','300',1,5,'    essay number 5\r\nsdfda\r\ndadss\r\n\r\nd\r\nfa\r\n\r\n',1,1),(200,2,'Essay','300',1,2,'    asdfsaf\r\nsdf\r\nfds\r\nfds\r\nafd\r\n',1,1),(200,2,'Essay','300',1,4,'    asfds\r\nasfds\r\nd\r\nff',1,1),(200,2,'Essay','300',2,2,'e',5,NULL),(200,2,'Essay','300',2,2,'f',5,NULL),(200,2,'Essay','300',2,1,'a',5,NULL),(200,2,'Essay','300',2,1,'b',5,NULL),(200,2,'Essay','300',2,1,'c',5,NULL),(200,2,'Essay','300',3,3,'true',2,NULL),(200,2,'Essay','300',3,1,'true',2,NULL),(200,2,'Essay','300',3,4,'false',0,NULL),(200,2,'Essay','300',3,2,'false',2,NULL);
/*!40000 ALTER TABLE `student_records` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_analysis`
--

DROP TABLE IF EXISTS `tbl_analysis`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tbl_analysis` (
  `col_analysis_id` int(11) NOT NULL AUTO_INCREMENT,
  `col_teacher_id` int(11) DEFAULT NULL,
  `col_exam_id` int(11) DEFAULT NULL,
  `col_exam_name` varchar(200) DEFAULT NULL,
  `col_part_no` int(11) DEFAULT NULL,
  `col_item_no` int(11) DEFAULT NULL,
  `col_question` varchar(200) DEFAULT NULL,
  `col_right_answers` int(11) DEFAULT NULL,
  `col_wrong_answers` int(11) DEFAULT NULL,
  PRIMARY KEY (`col_analysis_id`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_analysis`
--

LOCK TABLES `tbl_analysis` WRITE;
/*!40000 ALTER TABLE `tbl_analysis` DISABLE KEYS */;
INSERT INTO `tbl_analysis` VALUES (1,200,1,'periodical test 1st grading',1,2,'a',1,0),(2,200,1,'periodical test 1st grading',1,4,'c',1,0),(3,200,1,'periodical test 1st grading',1,1,'refers to the information generated, sent ,recieved or store by elecetronic optical',1,0),(4,200,1,'periodical test 1st grading',1,5,'e',1,0),(5,200,1,'periodical test 1st grading',1,3,'b',1,0),(6,200,1,'periodical test 1st grading',2,4,'d',1,0),(7,200,1,'periodical test 1st grading',2,1,'a',1,0),(8,200,1,'periodical test 1st grading',2,5,'e',1,0),(9,200,1,'periodical test 1st grading',2,3,'c',1,0),(10,200,1,'periodical test 1st grading',2,2,'b',1,0),(11,200,1,'periodical test 1st grading',3,2,'',0,1),(12,200,1,'periodical test 1st grading',3,3,'',0,1),(13,200,1,'periodical test 1st grading',3,1,'',0,1),(14,200,1,'periodical test 1st grading',4,3,'c',0,1),(15,200,1,'periodical test 1st grading',4,4,'d',0,1),(16,200,1,'periodical test 1st grading',4,5,'e',0,1),(17,200,1,'periodical test 1st grading',4,1,'a',0,1),(18,200,1,'periodical test 1st grading',4,2,'b',0,1),(19,200,1,'periodical test 1st grading',5,3,'C:\\Users\\Pau\\Desktop\\EQUIZ_PHOTO_GUESS\\SUPERCOMPUTER.jpeg',0,1),(20,200,1,'periodical test 1st grading',5,1,'C:\\Users\\Pau\\Desktop\\EQUIZ_PHOTO_GUESS\\MINI COMPUTER.jpeg',0,1),(21,200,1,'periodical test 1st grading',5,2,'C:\\Users\\Pau\\Desktop\\EQUIZ_PHOTO_GUESS\\PERSONAL COMPUTER.jpeg',0,1),(22,200,3,'identification',1,3,'keyboard',1,0),(23,200,3,'identification',1,1,'monitor',1,0),(24,200,3,'identification',1,2,'mouse',1,0),(25,200,2,'Essay',2,2,'d',0,1),(26,200,2,'Essay',2,1,'enumeration a',1,0),(27,200,2,'Essay',3,3,'true',1,0),(28,200,2,'Essay',3,1,'t',1,0),(29,200,2,'Essay',3,4,'false',0,1),(30,200,2,'Essay',3,2,'false',1,0);
/*!40000 ALTER TABLE `tbl_analysis` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_choices`
--

DROP TABLE IF EXISTS `tbl_choices`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tbl_choices` (
  `col_choice_id` int(11) NOT NULL AUTO_INCREMENT,
  `col_choices` varchar(45) DEFAULT NULL,
  `col_answer_flag` int(11) DEFAULT NULL,
  `col_exam_id` int(11) DEFAULT NULL,
  `col_part_id` int(11) DEFAULT NULL,
  `col_item_id` int(11) DEFAULT NULL,
  `col_choice_flag` int(11) DEFAULT NULL,
  `tbl_question_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`col_choice_id`)
) ENGINE=InnoDB AUTO_INCREMENT=53 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_choices`
--

LOCK TABLES `tbl_choices` WRITE;
/*!40000 ALTER TABLE `tbl_choices` DISABLE KEYS */;
INSERT INTO `tbl_choices` VALUES (1,'electronic signature',0,1,1,1,1,1),(2,'electronics data message',1,1,1,1,2,1),(3,'addressee',0,1,1,1,3,1),(4,'electrinic document',0,1,1,1,4,1),(5,'a',1,1,1,2,1,2),(6,'b',0,1,1,2,2,2),(7,'c',0,1,1,2,3,2),(8,'d',0,1,1,2,4,2),(9,'a',0,1,1,3,1,3),(10,'b',1,1,1,3,2,3),(11,'c',0,1,1,3,3,3),(12,'d',0,1,1,3,4,3),(13,'a',0,1,1,4,1,4),(14,'b',0,1,1,4,2,4),(15,'c',1,1,1,4,3,4),(16,'d',0,1,1,4,4,4),(17,'e',1,1,1,5,1,5),(18,'a',0,1,1,5,2,5),(19,'b',0,1,1,5,3,5),(20,'c',0,1,1,5,4,5),(21,'a',1,1,2,1,1,6),(22,'b',1,1,2,2,1,7),(23,'c',1,1,2,3,1,8),(24,'d',1,1,2,4,1,9),(25,'e',1,1,2,5,1,10),(26,'a',1,1,3,1,1,11),(27,'a',1,1,3,1,2,11),(28,'a',1,1,3,1,3,11),(29,'t',1,1,3,2,1,12),(30,'e',1,1,3,2,2,12),(31,'e',1,1,3,3,1,13),(32,'d',1,1,3,3,2,13),(33,'true',1,1,4,1,1,14),(34,'true',1,1,4,2,1,15),(35,'true',1,1,4,3,1,16),(36,'true',1,1,4,4,1,17),(37,'true',1,1,4,5,1,18),(38,'mini computer',1,1,5,1,1,19),(39,'personal computer',1,1,5,2,1,20),(40,'supercomputer',1,1,5,3,1,21),(41,'a',1,2,2,1,1,27),(42,'b',1,2,2,1,2,27),(43,'c',1,2,2,1,3,27),(44,'e',1,2,2,2,1,28),(45,'f',1,2,2,2,2,28),(46,'true',1,2,3,1,1,29),(47,'false',1,2,3,2,1,30),(48,'true',1,2,3,3,1,31),(49,'true',1,2,3,4,1,32),(50,'o',1,3,1,1,1,33),(51,'i',1,3,1,2,1,34),(52,'i',1,3,1,3,1,35);
/*!40000 ALTER TABLE `tbl_choices` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_exam`
--

DROP TABLE IF EXISTS `tbl_exam`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tbl_exam` (
  `col_exam_id` int(11) NOT NULL AUTO_INCREMENT,
  `col_exam_name` varchar(200) DEFAULT NULL,
  `col_exam_parts` int(11) DEFAULT NULL,
  `col_exam_grade` decimal(6,0) DEFAULT NULL,
  `col_exam_section` varchar(45) DEFAULT NULL,
  `col_exam_date` date DEFAULT NULL,
  `col_exam_duration_hrs` int(11) DEFAULT NULL,
  `col_exam_duration_mins` int(11) DEFAULT NULL,
  `col_exam_status` varchar(1) DEFAULT NULL,
  `col_teacher_id` int(11) DEFAULT NULL,
  `col_no_of_exams` decimal(6,0) DEFAULT NULL,
  `subject` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`col_exam_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_exam`
--

LOCK TABLES `tbl_exam` WRITE;
/*!40000 ALTER TABLE `tbl_exam` DISABLE KEYS */;
INSERT INTO `tbl_exam` VALUES (1,'periodical test 1st grading',5,9,'queen of love','2019-10-25',1,0,'1',200,25,'COMPUTER'),(2,'Essay',3,9,'queen of love','2019-10-25',1,0,'1',200,108,'COMPUTER'),(3,'identification',1,9,'queen of love','2019-10-25',1,0,'1',200,3,'COMPUTER');
/*!40000 ALTER TABLE `tbl_exam` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_parts`
--

DROP TABLE IF EXISTS `tbl_parts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tbl_parts` (
  `col_part_id` int(11) NOT NULL AUTO_INCREMENT,
  `col_part_no` int(11) DEFAULT NULL,
  `col_part_type` varchar(45) DEFAULT NULL,
  `col_part_items` int(11) DEFAULT NULL,
  `col_part_points` decimal(6,3) DEFAULT NULL,
  `col_exam_id` int(11) DEFAULT NULL,
  `col_part_level` varchar(45) DEFAULT NULL,
  `col_instructions` varchar(150) DEFAULT NULL,
  PRIMARY KEY (`col_part_id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_parts`
--

LOCK TABLES `tbl_parts` WRITE;
/*!40000 ALTER TABLE `tbl_parts` DISABLE KEYS */;
INSERT INTO `tbl_parts` VALUES (1,1,'Multiple Choice',5,1.000,1,'EASY','Select the best answer'),(2,2,'Identification',5,1.000,1,'MEDIUM','identify the following questions'),(3,3,'Enumeration',3,1.000,1,'EASY',''),(4,4,'true or false',5,1.000,1,'EASY','type true or false'),(5,5,'Photo Guest',3,1.000,1,'EASY',''),(6,1,'Essay',5,1.000,2,'EASY','essay type'),(7,2,'Enumeration',2,5.000,2,'MEDIUM','enumerate the following '),(8,3,'true or false',4,2.000,2,'EASY','true or false'),(9,1,'Identification',3,1.000,3,'EASY','Write I, if it belongs to input devices, O for output devices');
/*!40000 ALTER TABLE `tbl_parts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_question`
--

DROP TABLE IF EXISTS `tbl_question`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tbl_question` (
  `col_question_id` int(11) NOT NULL AUTO_INCREMENT,
  `col_question_no` int(11) DEFAULT NULL,
  `col_question` varchar(200) DEFAULT NULL,
  `col_part_id` int(11) DEFAULT NULL,
  `col_part_no` int(11) DEFAULT NULL,
  `col_exam_id` int(11) DEFAULT NULL,
  `col_no_choices` int(11) DEFAULT NULL,
  `col_points` int(11) DEFAULT NULL,
  PRIMARY KEY (`col_question_id`)
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_question`
--

LOCK TABLES `tbl_question` WRITE;
/*!40000 ALTER TABLE `tbl_question` DISABLE KEYS */;
INSERT INTO `tbl_question` VALUES (1,1,'refers to the information generated, sent ,recieved or store by elecetronic optical',1,1,1,4,0),(2,2,'a',1,1,1,4,0),(3,3,'b',1,1,1,4,0),(4,4,'c',1,1,1,4,0),(5,5,'e',1,1,1,4,0),(6,1,'a',2,2,1,2,0),(7,2,'b',2,2,1,1,0),(8,3,'c',2,2,1,1,0),(9,4,'d',2,2,1,1,0),(10,5,'e',2,2,1,1,0),(11,1,'input devices',3,3,1,3,0),(12,2,'output devices',3,3,1,2,0),(13,3,'top social media',3,3,1,2,0),(14,1,'a',4,4,1,2,0),(15,2,'b',4,4,1,2,0),(16,3,'c',4,4,1,2,0),(17,4,'d',4,4,1,2,0),(18,5,'e',4,4,1,2,0),(19,1,'C:\\Users\\Pau\\Desktop\\EQUIZ_PHOTO_GUESS\\MINI COMPUTER.jpeg',5,5,1,1,0),(20,2,'C:\\Users\\Pau\\Desktop\\EQUIZ_PHOTO_GUESS\\PERSONAL COMPUTER.jpeg',5,5,1,0,0),(21,3,'C:\\Users\\Pau\\Desktop\\EQUIZ_PHOTO_GUESS\\SUPERCOMPUTER.jpeg',5,5,1,0,0),(22,1,'make an essay',6,1,2,0,10),(23,2,'essay number 2',6,1,2,0,15),(24,3,'esssay number  3',6,1,2,0,20),(25,4,'esay number 4',6,1,2,0,5),(26,5,'essay number 5',6,1,2,0,20),(27,1,'enumeration a',7,2,2,3,0),(28,2,'d',7,2,2,2,0),(29,1,'t',8,3,2,2,0),(30,2,'false',8,3,2,2,0),(31,3,'true',8,3,2,2,0),(32,4,'false',8,3,2,2,0),(33,1,'monitor',9,1,3,2,0),(34,2,'mouse',9,1,3,1,0),(35,3,'keyboard',9,1,3,1,0);
/*!40000 ALTER TABLE `tbl_question` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `users` (
  `userid` int(200) NOT NULL,
  `userpass` varchar(30) DEFAULT NULL,
  `firstname` varchar(30) DEFAULT NULL,
  `middlename` varchar(20) DEFAULT NULL,
  `lastname` varchar(30) DEFAULT NULL,
  `position` varchar(10) DEFAULT NULL,
  `grade` varchar(15) DEFAULT NULL,
  `section` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`userid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-11-20 12:19:41
