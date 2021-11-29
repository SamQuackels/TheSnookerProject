-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 29, 2021 at 08:30 AM
-- Server version: 10.4.21-MariaDB
-- PHP Version: 7.3.31

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `snooker`
--

-- --------------------------------------------------------

--
-- Table structure for table `frames`
--

CREATE TABLE `frames` (
  `ID` int(11) NOT NULL,
  `timestamp` datetime NOT NULL,
  `user1ID` int(10) DEFAULT NULL,
  `user2ID` int(10) DEFAULT NULL,
  `user1won` tinyint(1) NOT NULL,
  `matchID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `groupmatches`
--

CREATE TABLE `groupmatches` (
  `ID` int(11) NOT NULL,
  `timestamp` datetime NOT NULL,
  `match1ID` int(11) DEFAULT NULL,
  `match2ID` int(11) DEFAULT NULL,
  `match3ID` int(11) DEFAULT NULL,
  `group1ID` int(11) DEFAULT NULL,
  `group2ID` int(11) DEFAULT NULL,
  `group1win` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `groups`
--

CREATE TABLE `groups` (
  `ID` int(11) NOT NULL,
  `user1ID` int(10) DEFAULT NULL,
  `userID2` int(10) DEFAULT NULL,
  `userID3` int(10) DEFAULT NULL,
  `naam` text NOT NULL,
  `foto` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `groups`
--

INSERT INTO `groups` (`ID`, `user1ID`, `userID2`, `userID3`, `naam`, `foto`) VALUES
(1, NULL, NULL, NULL, 'De Quackies', 'ab');

-- --------------------------------------------------------

--
-- Table structure for table `matches`
--

CREATE TABLE `matches` (
  `ID` int(11) NOT NULL,
  `Frame1ID` int(10) DEFAULT NULL,
  `Frame2ID` int(10) DEFAULT NULL,
  `Frame3ID` int(10) DEFAULT NULL,
  `user1won` tinyint(1) NOT NULL,
  `GroupMatchID` int(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `ID` int(11) NOT NULL,
  `name` text NOT NULL,
  `foto` text NOT NULL,
  `break` text CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL,
  `date` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`ID`, `name`, `foto`, `break`, `date`) VALUES
(1, 'Sam Quackels', 'foto.png', '52', '2021-11-23 13:26:58'),
(2, 'Jerry Bento', 'foto2.png', '53', '2021-11-23 13:27:26');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `frames`
--
ALTER TABLE `frames`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `matchidtoframe` (`matchID`),
  ADD KEY `user1idtoframe` (`user1ID`),
  ADD KEY `user2idtoframe` (`user2ID`);

--
-- Indexes for table `groupmatches`
--
ALTER TABLE `groupmatches`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `match1togroupmatch` (`match1ID`),
  ADD KEY `match2togroupmatch` (`match2ID`),
  ADD KEY `match3togroupmatch` (`match3ID`),
  ADD KEY `group1idtogroupmatch` (`group1ID`),
  ADD KEY `group2idtogroupmatch` (`group2ID`);

--
-- Indexes for table `groups`
--
ALTER TABLE `groups`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `user1IDtogroup` (`user1ID`),
  ADD KEY `user2IDtogroup` (`userID2`),
  ADD KEY `user3idtogroup` (`userID3`);

--
-- Indexes for table `matches`
--
ALTER TABLE `matches`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `groupmatchidtomatch` (`GroupMatchID`),
  ADD KEY `frame1idtomatch` (`Frame1ID`),
  ADD KEY `frame2idtomatch` (`Frame2ID`),
  ADD KEY `frame3idtomatch` (`Frame3ID`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `frames`
--
ALTER TABLE `frames`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `groupmatches`
--
ALTER TABLE `groupmatches`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `groups`
--
ALTER TABLE `groups`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `matches`
--
ALTER TABLE `matches`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `frames`
--
ALTER TABLE `frames`
  ADD CONSTRAINT `matchidtoframe` FOREIGN KEY (`matchID`) REFERENCES `matches` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `user1idtoframe` FOREIGN KEY (`user1ID`) REFERENCES `users` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `user2idtoframe` FOREIGN KEY (`user2ID`) REFERENCES `users` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Constraints for table `groupmatches`
--
ALTER TABLE `groupmatches`
  ADD CONSTRAINT `group1idtogroupmatch` FOREIGN KEY (`group1ID`) REFERENCES `groups` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `group2idtogroupmatch` FOREIGN KEY (`group2ID`) REFERENCES `groups` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `match1togroupmatch` FOREIGN KEY (`match1ID`) REFERENCES `matches` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `match2togroupmatch` FOREIGN KEY (`match2ID`) REFERENCES `matches` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `match3togroupmatch` FOREIGN KEY (`match3ID`) REFERENCES `matches` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Constraints for table `groups`
--
ALTER TABLE `groups`
  ADD CONSTRAINT `user1IDtogroup` FOREIGN KEY (`user1ID`) REFERENCES `users` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `user2IDtogroup` FOREIGN KEY (`userID2`) REFERENCES `users` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `user3idtogroup` FOREIGN KEY (`userID3`) REFERENCES `users` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Constraints for table `matches`
--
ALTER TABLE `matches`
  ADD CONSTRAINT `frame1idtomatch` FOREIGN KEY (`Frame1ID`) REFERENCES `frames` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `frame2idtomatch` FOREIGN KEY (`Frame2ID`) REFERENCES `frames` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `frame3idtomatch` FOREIGN KEY (`Frame3ID`) REFERENCES `frames` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `groupmatchidtomatch` FOREIGN KEY (`GroupMatchID`) REFERENCES `groupmatches` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
