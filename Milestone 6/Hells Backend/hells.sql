-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 29, 2018 at 04:26 AM
-- Server version: 10.1.28-MariaDB
-- PHP Version: 7.1.11

--
-- Database: `ellia20i`
--

-- --------------------------------------------------------

--
-- Table structure for table `analyst`
--

CREATE TABLE `analyst` (
  `analyst_id` int(10) NOT NULL,
  `first_name` varchar(30) NOT NULL,
  `last_name` varchar(30) NOT NULL,
  `user_name` varchar(30) NOT NULL,
  `email` varchar(50) NOT NULL,
  `password` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `analyst`
--

INSERT INTO `analyst` (`analyst_id`, `first_name`, `last_name`, `user_name`, `email`, `password`) VALUES
(1, 'test', 'testacc', 'test', 'test@testanalyst.com', 'test');

-- --------------------------------------------------------

--
-- Table structure for table `approver`
--

CREATE TABLE `approver` (
  `approver_id` int(10) NOT NULL,
  `first_name` varchar(30) NOT NULL,
  `last_name` varchar(30) NOT NULL,
  `user_name` varchar(30) NOT NULL,
  `email` varchar(50) NOT NULL,
  `password` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `approver`
--

INSERT INTO `approver` (`approver_id`, `first_name`, `last_name`, `user_name`, `email`, `password`) VALUES
(1, 'Al', 'Dente', 'al_dente', 'al_dente@hell.ca', 'test'),
(2, 'Al', 'Falfa', 'al_falfa', 'al_falfa@hell.ca', 'test'),
(3, 'Alan', 'Rench', 'alan_rench', 'alan_rench@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(4, 'Amanda', 'Huginkiss', 'amanda_huginkiss', 'amanda_huginkiss@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(5, 'Anna', 'Conda', 'anna_conda', 'anna_conda@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(6, 'Anna', 'Nimmity', 'anna_nimmity', 'anna_nimmity@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(7, 'Anne', 'Thrax', 'anne_thrax', 'anne_thrax@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(8, 'Annita', 'Job', 'annita_job', 'annita_job@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(9, 'Art', 'Choake', 'art_choake', 'art_choake@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(10, 'Art', 'Dekko', 'art_dekko', 'art_dekko@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(11, 'Art', 'major', 'art_major', 'art_major@hell.ca	', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(12, 'Barb', 'Wyre', 'barb_wyre', 'barb_wyre@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(13, 'Benny', 'Fitz', 'benny_fitz', 'benny_fitz@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(14, 'Biff', 'Wellington', 'biff_wellington', 'biff_wellington@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(15, 'Brock', 'Lee', 'brock_lee', 'brock_lee@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(16, 'Bud', 'Light', 'bud_light', 'bud_light@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(17, 'Bunsen', 'Burner', 'bunsen_burner', 'bunsen_burner@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(18, 'Chester', 'Field', 'chester_field', 'chester_field@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(19, 'Claire', 'Voyant', 'claire_voyant', 'claire_voyant@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(20, 'Clay', 'Potts', 'clay_potts', 'clay_potts@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(21, 'Crystal', 'Ball', 'crystal_ball', 'crystal_ball@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(22, 'Derry', 'Yare', 'derry_yare', 'derry_yare@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(23, 'Dot', 'Matricks', 'dot_matricks', 'dot_matricks@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(24, 'Douglas', 'Furr', 'douglas_furr', 'douglas_furr@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(25, 'Chris', 'Bacon', 'chris_bacon', 'chris_bacon@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(26, 'Jed', 'Knight', 'jed_night', 'jed_night@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(27, 'Dyl', 'Pickel', 'dyl_pickel', 'dyl_pickel@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(28, 'Filet', 'Minyon', 'filet_minyon', 'filet_minyon@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(29, 'Frank', 'Furter', 'frank_furter', 'frank_furter@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(30, 'Gene', 'Poole', 'gene_poole', 'gene_poole@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(31, 'Ginger', 'Vitus', 'ginger_vitus', 'ginger_vitus@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(32, 'Gladys', 'Dunn', 'gladys_dunn', 'gladys_dunn@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(33, 'Goldie', 'Locke', 'goldie_lock', 'goldie_lock@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(34, 'Harry', 'Beard', 'harry_beard', 'harry_beard@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(35, 'Honey', 'Potts', 'honey_potts', 'honey_potts@hell.ca	', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(36, 'Ida', 'Claire', 'ida_claire', 'ida_claire@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(37, 'Jack', 'Uzzi', 'jack_uzzi', 'jack_uzzi@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(38, 'Justin', 'Case', 'justin_case', 'justin_case@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(39, 'Justin', 'Thyme', 'justin_thyme', 'justin_thyme@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(40, 'Kayne', 'Kun', 'kayne_kun', 'kayne_kun@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(41, 'Krystal', 'Ball', 'krystal_ball', 'krystal_ball@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(42, 'Leah', 'Tarde', 'leah_tarde', 'leah_tarde@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(43, 'Les', 'Wynan', 'les_wynan', 'les_wynan@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(44, 'Linda', 'Hand', 'linda_hand', 'linda_hand@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(45, 'Lotta', 'Noyes', 'lotta_noyes', 'lotta_noyes@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(46, 'Mason', 'Jarr', 'mason_Jarr', 'mason_Jarr@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(47, 'Mike', 'Raffone', 'mike_raffone', 'mike_raffone@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(48, 'Neil', 'Down', 'neil_down', 'neil_down@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(49, 'Ollie', 'Gark', 'ollie_gark', 'ollie_gark@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(50, 'Paige', 'Turner', 'paige_turner', 'paige_turner@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(51, 'Pea', 'Pu', 'pea_pu', 'pea_pu@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(52, 'Pete', 'Moss', 'pete_moss', 'pete_moss@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(53, 'Polly', 'Graff', 'polly_graff', 'polly_graff@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(54, 'Robyn', 'Banks', 'robyn_banks', 'robyn_banks@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(55, 'Rocky', 'Rhodes', 'rocky_rhodes', 'rocky_rhodes@hell.ca', 'test'),
(56, 'Rod', 'Curtains', 'rod_curtains', 'rod_curtains@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(57, 'Rusty', 'Foord', 'rusty_foord', 'rusty_foord@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(58, 'Sandy', 'Beech', 'sandy_beech', 'sandy_beech@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(59, 'Seymore', 'Butts', 'seymore_butts', 'seymore_butts@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(60, 'Sonny', 'Day', 'sonny_day', 'sonny_day@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(61, 'Stan', 'Dupp', 'stan_dupp', 'stan_dupp@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(62, 'Sue', 'Flay', 'sue_flay', 'sue_flay@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(63, 'Sue', 'Vlaki', 'sue_vlaki', 'sue_vlaki@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(64, 'Tara', 'Dactyl', 'tara_dactyl', 'tara_dactyl@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(65, 'Tess', 'Tamoni', 'tess_tamoni', 'tess_tamoni@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(66, 'Tom', 'Foolery', 'tom_foolery', 'tom_foolery@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(67, 'Ty', 'Kuhn', 'ty_kuhn', 'ty_kuhn@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(68, 'Warren', 'Peace', 'warren_peace', 'warren_peace@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(69, 'Wazziz', 'Naime', 'wazziz_naime', 'wazziz_naime@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(70, 'Wil', 'Doolittle', 'wil_doolittle', 'wil_doolittle@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9'),
(71, 'Will', 'Tickelu', 'will_tickelu', 'will_tickelu@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e9');

-- --------------------------------------------------------

--
-- Table structure for table `hells_software`
--

CREATE TABLE `hells_software` (
  `approver_id` int(10) NOT NULL,
  `first_name` varchar(30) NOT NULL,
  `last_name` varchar(30) NOT NULL,
  `software_id` int(10) NOT NULL,
  `software_name` varchar(30) NOT NULL,
  `software_acronym` varchar(10) NOT NULL,
  `software_province` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `hells_software`
--

INSERT INTO `hells_software` (`approver_id`, `first_name`, `last_name`, `software_id`, `software_name`, `software_acronym`, `software_province`) VALUES
(1, 'Al', 'Dente', 1, 'Remote Health Checker', '', ''),
(1, 'Al', 'Dente', 2, 'Remote Stroke Checker', '', ''),
(1, 'Al', 'Dente', 3, 'TeleCare', '', ''),
(2, 'Al', 'Falfa', 4, 'Lab Information System', 'LIS', ''),
(2, 'Al', 'Pacca', 5, 'myeHealth', '', 'YK-NT-NU'),
(3, 'Alan', 'Rench', 6, 'Pollution Alerts Datamart', 'PAD', ''),
(4, 'Amanda', 'Huginkiss', 7, 'Limited Operating liability', 'LOL', ''),
(5, 'Anna', 'Conda', 8, 'Environmental Assessor Tool', '', ''),
(6, 'Anna ', 'Nimmity', 9, 'MicroStrategy', '', ''),
(7, 'Anna', 'Thrax', 10, 'Water and Land Data Observer', 'WALDO', ''),
(8, 'Annita', 'Job', 11, 'Waste Observation System', '', ''),
(9, 'Art', 'Choake', 12, 'Weather Analyzer Software Syst', 'WASSUP', ''),
(10, 'Art', 'Dekko', 13, 'Ambulance Schedule System', '', ''),
(11, 'Art', 'Major', 14, 'myeHealth', '', 'ON'),
(12, 'Barb', 'Wyre', 15, 'Netcare Occupation & Observati', 'NOOBS', ''),
(13, 'Benny', 'Fitz', 16, 'Weather and Ozone Observation ', 'WOOKEEE', ''),
(14, 'Biff', 'Wellington', 17, 'Chronic Disease Management', '', ''),
(15, 'Brock', 'Lee', 18, 'World Terrain & Forestry', 'WTF', ''),
(16, 'Bud', 'Light', 19, 'Selected Analytical Methods', 'SAM', ''),
(17, 'Bunson', 'Burner', 20, 'Find A Doctor', 'FAD', ''),
(18, 'Chester', 'Field', 21, 'Operating Map of Gastropathy', 'OMG', ''),
(19, 'Chaire', 'Voyant', 22, 'List of Transactions and Redac', 'LOTR', ''),
(20, 'Clay Potts', '', 23, 'Care Manager', '', ''),
(21, 'Crystal', 'Ball', 24, 'Drug Profile Viewer', 'DPV', ''),
(21, 'Crystal', 'Ball', 25, 'Pharmaceutical Information Pro', 'PIP', ''),
(22, 'Derry', 'Yare', 26, 'Heart Abdomen and Head Assesso', 'HAHA', ''),
(23, 'Dot', 'Matricks', 27, 'Web Utility Table', 'WUT', ''),
(24, 'Douglas', 'Furr', 28, 'TeleCare', '', ''),
(24, 'Douglas', 'Furr', 29, 'Remote Stroke Checker', '', ''),
(24, 'Douglas', 'Furr', 30, 'Remote Health Checker', '', ''),
(25, 'Chris', 'Bacon', 31, 'Heart Ultrasound Heatmaps', 'HUH', ''),
(26, 'Jed', 'Knight', 32, 'Radiology Information Systems', 'RIS', ''),
(27, 'Dyl', 'Pickel', 33, 'Snowmed Analyzer System Extend', 'SASEE', ''),
(28, 'Filet', 'Minyon', 34, 'Storm Water Management', '', ''),
(29, 'Frank', 'Furter', 35, 'Patient Admitter Tool', 'PAT', ''),
(30, 'Gene', 'Poole', 36, 'Fast Family Finder', '', ''),
(31, 'Ginger', 'Vitus', 37, 'Provider Coverage Viewer', 'PCV', ''),
(32, 'Gladys', 'Dunn', 38, 'Surgical Information System', 'SIS', ''),
(33, 'Goldie', 'locke', 39, 'Data & Utility Heuristics', 'DUH', ''),
(34, 'Harry', 'Beard', 40, 'Spillage Locator Tool', '', ''),
(35, 'Honey', 'Potts', 41, 'Biosphere Air and Gas Interpre', '', ''),
(36, 'Ida', 'Claire', 42, 'Abdomen Tissue and Analysis To', 'AT-AT', ''),
(36, 'Ida', 'Claire', 43, 'Operating Map of Gastropathy', 'OMG', ''),
(37, 'Jack', 'Uzzi', 44, 'Transcription Magic Interprete', 'TMI', ''),
(38, 'Justin', 'Case', 45, 'Download Urgent Medical Backup', 'DUMB', ''),
(39, 'Justin', 'Thyme', 46, 'Statistical Analysis System', 'SAS', ''),
(40, 'Kayne', 'Kun', 47, 'eReferral', '', ''),
(41, 'Krystal', 'Ball', 48, 'Waste Electronic & Wireless Eq', 'WEWE', ''),
(42, 'Leah', 'Tarde', 49, 'National Ozone Observatory Bot', 'NOOB', ''),
(43, 'Les', 'Wynan', 50, 'Total Mastering of Incisions', 'TMI', ''),
(44, 'Linda', 'Hand', 51, 'Environmental Home Manager', '', ''),
(45, 'Lotta', 'Noyes', 52, 'Clinical Data Repository', 'CDR', ''),
(46, 'Mason', 'Jarr', 53, 'PharmaCare', '', ''),
(47, 'Mike', 'Raffone', 54, 'myeHealth', '', 'NB-PE-NS-N'),
(48, 'Neil', 'Down', 55, 'Sustainable Xeriscaping', 'SUX', ''),
(49, 'Ollie', 'Gark', 56, 'Statistical Package for Social', 'SPSS', ''),
(50, 'Paige', 'Turner', 57, 'Picture Archive and Communicat', 'PACS', ''),
(51, 'Pea', 'Pu', 58, 'Drug Profile Viewer', 'DPV', ''),
(51, 'Pea', 'Pu', 59, 'Pharmaceutical Information Pro', 'PIP', ''),
(52, 'Pete', 'Moss', 60, 'Cisco WebEx', '', ''),
(53, 'Polly', 'Graff', 61, 'Alternative Sewage System', '', ''),
(54, 'Robyn', 'Banks', 62, 'Planetary Environmental Refere', 'PERS', ''),
(55, 'Rocky', 'Rhodes', 63, 'myeHealth', '', 'AB-SK-MB'),
(56, 'Rod', 'Curtains', 64, 'myehealth', '', 'BC'),
(57, 'Rusty', 'Foord', 65, 'Homecare System', '', ''),
(58, 'Sandy', 'Beech', 66, 'Cleaning Product Analyzer', '', ''),
(59, 'Seymore', 'Butts', 67, 'Original Record of Landscape a', 'ORLY', ''),
(60, 'Sonny', 'Day', 68, 'Clinical Admission Manager', '', ''),
(61, 'Stan', 'Dupp', 69, 'Relational Observation System ', 'ROFL', ''),
(62, 'Sue', 'Flay', 70, 'Free MySQL Logger', 'FML', ''),
(63, 'Sue', 'Vlaki', 71, 'Greenhouse Gas Analyzer', '', ''),
(64, 'Tara', 'Dactyl', 72, 'Fixed Orthodontic Medical Oper', 'FOMO', ''),
(65, 'Tess', 'Tamoni', 73, 'myeHealth', '', ''),
(66, 'Tom', 'Foolery', 74, 'Electronic Medical Record (Vie', 'EMR', ''),
(67, 'Ty', 'Kuhn', 75, 'Provider Registry System', 'PRS', ''),
(68, 'Warren', 'Peace', 76, 'eHealthChart', '', ''),
(69, 'Wazziz', 'naime', 77, 'Electronic Lab System Interpol', 'ELSI', ''),
(70, 'Wil', 'Doolittle', 78, 'Ambulance Supply System', '', ''),
(71, 'Will', 'Tickelu', 79, 'Northern Ozone & Ocean Biome', 'NOOB', '');

-- --------------------------------------------------------

--
-- Table structure for table `hells_user`
--

CREATE TABLE `hells_user` (
  `user_id` int(10) NOT NULL,
  `user_name` varchar(30) NOT NULL,
  `email` varchar(50) NOT NULL,
  `password` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `hells_user`
--

INSERT INTO `hells_user` (`user_id`, `user_name`, `email`, `password`) VALUES
(1, 'test', 'test@test.com', 'testpass'),
(6, 'test2', 'testuser@email.com', 'testpass'),
(7, 'te2st2', 'testuser@email.com', 'testpass'),
(8, 'test23', 'sfs@gm.com', '123');

-- --------------------------------------------------------

--
-- Table structure for table `software_request`
--

CREATE TABLE `software_request` (
  `user_id` int(10) NOT NULL,
  `software_id` int(10) NOT NULL,
  `approver_id` int(10) NOT NULL,
  `approved_status` varchar(50) NOT NULL DEFAULT 'pending'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `software_request`
--

INSERT INTO `software_request` (`user_id`, `software_id`, `approver_id`, `approved_status`) VALUES
(1, 70, 62, 'pending approval'),
(1, 1, 1, 'denied'),
(1, 2, 1, 'pending'),
(1, 26, 22, 'pending approval'),
(1, 27, 23, 'pending'),
(1, 28, 24, 'pending'),
(1, 76, 68, 'pending'),
(1, 73, 65, 'pending'),
(1, 74, 66, 'pending'),
(8, 1, 1, 'pending'),
(8, 2, 1, 'pending'),
(1, 3, 1, 'pending'),
(1, 4, 2, 'pending'),
(1, 5, 2, 'pending'),
(1, 6, 3, 'pending'),
(1, 7, 4, 'pending'),
(1, 11, 8, 'pending'),
(1, 29, 24, 'pending'),
(1, 8, 5, 'pending'),
(1, 9, 6, 'pending'),
(1, 30, 24, 'pending'),
(1, 33, 27, 'pending'),
(1, 35, 29, 'pending'),
(1, 36, 30, 'pending'),
(1, 44, 37, 'pending'),
(1, 45, 38, 'pending'),
(1, 46, 39, 'pending'),
(1, 47, 40, 'pending'),
(1, 49, 42, 'pending'),
(1, 50, 43, 'pending'),
(1, 12, 9, 'pending'),
(1, 10, 7, 'pending'),
(1, 13, 10, 'pending'),
(1, 14, 11, 'pending'),
(1, 15, 12, 'pending'),
(8, 3, 1, 'pending'),
(8, 4, 2, 'pending'),
(8, 5, 2, 'pending'),
(8, 63, 55, 'approved|access'),
(8, 64, 56, 'pending approval');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `analyst`
--
ALTER TABLE `analyst`
  ADD PRIMARY KEY (`analyst_id`);

--
-- Indexes for table `approver`
--
ALTER TABLE `approver`
  ADD PRIMARY KEY (`approver_id`);

--
-- Indexes for table `hells_software`
--
ALTER TABLE `hells_software`
  ADD PRIMARY KEY (`software_id`);

--
-- Indexes for table `hells_user`
--
ALTER TABLE `hells_user`
  ADD PRIMARY KEY (`user_id`);

--
-- Indexes for table `software_request`
--
ALTER TABLE `software_request`
  ADD KEY `user_id` (`user_id`),
  ADD KEY `approver_id` (`approver_id`),
  ADD KEY `software_id` (`software_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `analyst`
--
ALTER TABLE `analyst`
  MODIFY `analyst_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `hells_user`
--
ALTER TABLE `hells_user`
  MODIFY `user_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `software_request`
--
ALTER TABLE `software_request`
  ADD CONSTRAINT `software_request_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `hells_user` (`user_id`),
  ADD CONSTRAINT `software_request_ibfk_2` FOREIGN KEY (`approver_id`) REFERENCES `approver` (`approver_id`),
  ADD CONSTRAINT `software_request_ibfk_3` FOREIGN KEY (`software_id`) REFERENCES `hells_software` (`software_id`);
COMMIT;