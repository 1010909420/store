# SQL-Front 5.1  (Build 4.16)

/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE */;
/*!40101 SET SQL_MODE='NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES */;
/*!40103 SET SQL_NOTES='ON' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS */;
/*!40014 SET FOREIGN_KEY_CHECKS=0 */;


# Host: localhost    Database: store
# ------------------------------------------------------
# Server version 5.1.73-community

#
# Source for table t_addr
#

DROP TABLE IF EXISTS `t_addr`;
CREATE TABLE `t_addr` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `userId` int(11) DEFAULT NULL,
  `addr` varchar(800) DEFAULT NULL COMMENT '地址',
  `mobile` varchar(80) DEFAULT NULL COMMENT '联系电话',
  `name` varchar(255) DEFAULT NULL COMMENT '收件人姓名',
  PRIMARY KEY (`id`),
  KEY `fk_addr_userId` (`userId`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COMMENT='用户地址表';

#
# Dumping data for table t_addr
#

LOCK TABLES `t_addr` WRITE;
/*!40000 ALTER TABLE `t_addr` DISABLE KEYS */;
INSERT INTO `t_addr` VALUES (1,1,'北京',NULL,NULL);
INSERT INTO `t_addr` VALUES (2,2,'广州',NULL,NULL);
INSERT INTO `t_addr` VALUES (3,3,'上海',NULL,NULL);
INSERT INTO `t_addr` VALUES (4,4,'深圳',NULL,NULL);
INSERT INTO `t_addr` VALUES (5,5,'成都',NULL,NULL);
/*!40000 ALTER TABLE `t_addr` ENABLE KEYS */;
UNLOCK TABLES;

#
# Source for table t_comment
#

DROP TABLE IF EXISTS `t_comment`;
CREATE TABLE `t_comment` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `userId` int(11) DEFAULT NULL,
  `goodsId` int(11) DEFAULT NULL,
  `content` varchar(800) DEFAULT '' COMMENT '评论内容',
  `picture` varchar(800) DEFAULT '' COMMENT '评论图片',
  `grade` int(11) DEFAULT NULL COMMENT '评分',
  PRIMARY KEY (`id`),
  KEY `fk_comment_userId` (`userId`),
  KEY `fk_comment_goodsId` (`goodsId`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8 COMMENT='评论表';

#
# Dumping data for table t_comment
#

LOCK TABLES `t_comment` WRITE;
/*!40000 ALTER TABLE `t_comment` DISABLE KEYS */;
INSERT INTO `t_comment` VALUES (1,1,1,'啊~肥宅快乐！','',5);
INSERT INTO `t_comment` VALUES (2,2,1,'碳酸饮料还是少喝点好！','',3);
INSERT INTO `t_comment` VALUES (3,3,3,'三块五还算便宜。','',5);
INSERT INTO `t_comment` VALUES (4,4,2,'杯子一点都不隔热，不过还算便宜...','',3);
INSERT INTO `t_comment` VALUES (5,5,2,'杯子装热水杯口就会漏水，挺严重的。','',3);
INSERT INTO `t_comment` VALUES (6,1,2,'放着放着就裂了？？没磕到啊，怎么回事啊！','',1);
INSERT INTO `t_comment` VALUES (8,5,2,'哈哈。','123',3);
/*!40000 ALTER TABLE `t_comment` ENABLE KEYS */;
UNLOCK TABLES;

#
# Source for table t_goods
#

DROP TABLE IF EXISTS `t_goods`;
CREATE TABLE `t_goods` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL COMMENT '商品名',
  `price` decimal(18,2) DEFAULT NULL COMMENT '单价',
  `presentation` varchar(800) DEFAULT NULL COMMENT '商品介绍',
  `inventory` int(11) DEFAULT NULL COMMENT '库存',
  `quantity` int(11) DEFAULT NULL COMMENT '已售数量',
  `pictureUrl1` varchar(800) DEFAULT 'null' COMMENT '图片1',
  `pictureUrl2` varchar(800) DEFAULT 'null' COMMENT '图片2',
  `pictureUrl3` varchar(800) DEFAULT 'null' COMMENT '图片3',
  `pictureUrl4` varchar(800) DEFAULT 'null' COMMENT '图片4',
  `pictureUrl5` varchar(800) DEFAULT 'null' COMMENT '图片5',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COMMENT='商品表';

#
# Dumping data for table t_goods
#

LOCK TABLES `t_goods` WRITE;
/*!40000 ALTER TABLE `t_goods` DISABLE KEYS */;
INSERT INTO `t_goods` VALUES (1,'百事可乐',3.5,'550ml快乐水',68,74,'/upload/aee6b2d8-796b-443e-8fa8-ed51347fe63b.JPG','null','null','null','null');
INSERT INTO `t_goods` VALUES (2,'玻璃杯',16.9,'300ml隔热玻璃杯',12,152,'/upload/45030b91-0a08-4a9c-9659-3b1e9e5889ad.JPG','null','null','null','null');
INSERT INTO `t_goods` VALUES (3,'维达纸巾',3.5,'300抽维达纸巾',75,510,'null','null','null','null','null');
/*!40000 ALTER TABLE `t_goods` ENABLE KEYS */;
UNLOCK TABLES;

#
# Source for table t_order
#

DROP TABLE IF EXISTS `t_order`;
CREATE TABLE `t_order` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `userId` int(11) DEFAULT NULL,
  `goodsId` int(11) DEFAULT NULL,
  `addrId` int(11) DEFAULT NULL,
  `quantity` int(11) DEFAULT NULL COMMENT '购买数量',
  PRIMARY KEY (`id`),
  KEY `fk_order_userId` (`userId`),
  KEY `fk_order_goodsId` (`goodsId`),
  KEY `fk_order_addrId` (`addrId`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COMMENT='订单表';

#
# Dumping data for table t_order
#

LOCK TABLES `t_order` WRITE;
/*!40000 ALTER TABLE `t_order` DISABLE KEYS */;
INSERT INTO `t_order` VALUES (1,1,1,1,5);
INSERT INTO `t_order` VALUES (2,2,1,2,3);
/*!40000 ALTER TABLE `t_order` ENABLE KEYS */;
UNLOCK TABLES;

#
# Source for table t_shoppingcart
#

DROP TABLE IF EXISTS `t_shoppingcart`;
CREATE TABLE `t_shoppingcart` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `userId` int(11) DEFAULT NULL,
  `goodsId` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_shoppingcart_userId` (`userId`),
  KEY `fk_shoppingcartgoodsId` (`goodsId`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COMMENT='购物车表';

#
# Dumping data for table t_shoppingcart
#

LOCK TABLES `t_shoppingcart` WRITE;
/*!40000 ALTER TABLE `t_shoppingcart` DISABLE KEYS */;
INSERT INTO `t_shoppingcart` VALUES (1,1,1);
INSERT INTO `t_shoppingcart` VALUES (2,1,2);
INSERT INTO `t_shoppingcart` VALUES (3,1,2);
INSERT INTO `t_shoppingcart` VALUES (4,2,2);
INSERT INTO `t_shoppingcart` VALUES (5,2,2);
/*!40000 ALTER TABLE `t_shoppingcart` ENABLE KEYS */;
UNLOCK TABLES;

#
# Source for table t_user
#

DROP TABLE IF EXISTS `t_user`;
CREATE TABLE `t_user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `account` varchar(64) DEFAULT NULL COMMENT '账号',
  `password` varchar(64) DEFAULT NULL COMMENT '密码',
  `name` varchar(255) DEFAULT NULL COMMENT '姓名',
  `age` int(11) DEFAULT NULL COMMENT '年龄',
  `sex` int(11) DEFAULT NULL COMMENT '性别',
  `level` int(11) DEFAULT NULL COMMENT '用户等级',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COMMENT='用户表';

#
# Dumping data for table t_user
#

LOCK TABLES `t_user` WRITE;
/*!40000 ALTER TABLE `t_user` DISABLE KEYS */;
INSERT INTO `t_user` VALUES (1,'xiaoming',NULL,'小明',16,0,0);
INSERT INTO `t_user` VALUES (2,'xiaohong',NULL,'小红',15,1,0);
INSERT INTO `t_user` VALUES (3,'xiaogang',NULL,'小刚',18,0,0);
INSERT INTO `t_user` VALUES (4,'xiaocheng',NULL,'小橙',17,1,0);
INSERT INTO `t_user` VALUES (5,'xiaoli','202cb962ac59075b964b07152d234b70','小李',17,0,1);
/*!40000 ALTER TABLE `t_user` ENABLE KEYS */;
UNLOCK TABLES;

#
#  Foreign keys for table t_addr
#

ALTER TABLE `t_addr`
ADD CONSTRAINT `fk_addr_userId` FOREIGN KEY (`userId`) REFERENCES `t_user` (`id`);

#
#  Foreign keys for table t_comment
#

ALTER TABLE `t_comment`
ADD CONSTRAINT `fk_comment_goodsId` FOREIGN KEY (`goodsId`) REFERENCES `t_goods` (`id`),
ADD CONSTRAINT `fk_comment_userId` FOREIGN KEY (`userId`) REFERENCES `t_user` (`id`);

#
#  Foreign keys for table t_order
#

ALTER TABLE `t_order`
ADD CONSTRAINT `fk_order_addrId` FOREIGN KEY (`addrId`) REFERENCES `t_addr` (`id`),
ADD CONSTRAINT `fk_order_goodsId` FOREIGN KEY (`goodsId`) REFERENCES `t_goods` (`id`),
ADD CONSTRAINT `fk_order_userId` FOREIGN KEY (`userId`) REFERENCES `t_user` (`id`);

#
#  Foreign keys for table t_shoppingcart
#

ALTER TABLE `t_shoppingcart`
ADD CONSTRAINT `fk_shoppingcartgoodsId` FOREIGN KEY (`goodsId`) REFERENCES `t_goods` (`id`),
ADD CONSTRAINT `fk_shoppingcart_userId` FOREIGN KEY (`userId`) REFERENCES `t_user` (`id`);


/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
