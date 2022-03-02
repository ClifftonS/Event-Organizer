-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 04, 2021 at 01:01 PM
-- Server version: 10.4.17-MariaDB
-- PHP Version: 7.3.27

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `loketdotcom`
--

-- --------------------------------------------------------

--
-- Table structure for table `detail_trans_beli_tiket`
--

CREATE TABLE `detail_trans_beli_tiket` (
  `ID_TRANS` varchar(30) NOT NULL,
  `KATEGORI_TIKET` varchar(50) NOT NULL,
  `BELI_QTY` int(11) UNSIGNED NOT NULL,
  `BELI_HARGA` int(11) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `detail_trans_beli_tiket`
--

INSERT INTO `detail_trans_beli_tiket` (`ID_TRANS`, `KATEGORI_TIKET`, `BELI_QTY`, `BELI_HARGA`) VALUES
('INV0001', 'Live Webinar + Recording', 2, 400000),
('INV0002', 'Show 1', 1, 600000),
('INV0002', 'Show 2', 2, 1200000);

-- --------------------------------------------------------

--
-- Table structure for table `event_acara`
--

CREATE TABLE `event_acara` (
  `JUDUL_EVENT` varchar(100) NOT NULL,
  `NAMA_P` varchar(50) NOT NULL,
  `TGL_EVENT` date NOT NULL,
  `KATEGORI_EVENT` varchar(50) NOT NULL,
  `DESKRIPSI_EVENT` varchar(300) NOT NULL,
  `LOKASI_EVENT` varchar(50) NOT NULL,
  `ALAMAT_EVENT` varchar(100) DEFAULT NULL,
  `WAKTU_EVENT` varchar(45) DEFAULT NULL,
  `URL_EVENT` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `event_acara`
--

INSERT INTO `event_acara` (`JUDUL_EVENT`, `NAMA_P`, `TGL_EVENT`, `KATEGORI_EVENT`, `DESKRIPSI_EVENT`, `LOKASI_EVENT`, `ALAMAT_EVENT`, `WAKTU_EVENT`, `URL_EVENT`) VALUES
('How To Invest ETF', 'Sahamology', '2021-06-30', 'Workshop', 'Dulu kita kenal reksadana, kini market sudah berkembang dan hasilkan produk yang bernama ETF. ETF ini mirip dengan reksadana cuma bisa diperdagangkan seperti saham. Jadi relative lebih menarik', 'Event Online', 'Zoom', '18:00-21:00', 'C:/Users/cliff/Documents/Kuliah/Sem2/AD/SAA/How To Invest ETF in Wall Street.png'),
('Komoidoumenoi', 'Comica Ent', '2021-09-21', 'Concert', 'Sebelum konser harus memperhatikan beberapa hal berikut:\r\n1.Wajib mengikuti Protokol Kesehatan acara Komoidoumenoi World Tour yang dapat di unduh di tersinggungolehpandji.com \r\n2. Acara ini untuk 15+ \r\n3. Tidak diperkenankan untuk membawa anak, dll', 'Surabaya', 'Istora Senayan', '17:00-21:00', 'C:/Users/cliff/Documents/Kuliah/Sem2/AD/SAA/komoidoumenoi.png'),
('Peluang Usaha Tanpa Modal', 'AsiaCommerce', '2021-06-18', 'Workshop', 'Yuk kupas secara mendalam bisnis Dropship dan Reseller yang bisa dilakukan kapanpun dan dimanapun dalam Webinar “PELUANG USAHA TANPA MODAL #ANTIRIBET Batch 4”. Event ini bertujuan untuk memberikan edukasi peluang bisnis dan step-by-step guide cara pengembangan bisnis online', 'Event Online', 'Zoom', '16:00-18:00', 'C:/Users/cliff/Documents/Kuliah/Sem2/AD/SAA/Peluang Usaha Tanpa Modal.png');

-- --------------------------------------------------------

--
-- Table structure for table `pengguna`
--

CREATE TABLE `pengguna` (
  `USERNAME` varchar(50) NOT NULL,
  `PASSWORD` varchar(45) NOT NULL,
  `NAMA` varchar(50) NOT NULL,
  `NO_HP` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `pengguna`
--

INSERT INTO `pengguna` (`USERNAME`, `PASSWORD`, `NAMA`, `NO_HP`) VALUES
('dimas.aditya123', 'dimas456', 'Dimas Aditya', '087348713492'),
('fiorenza_the', 'fififio', 'Fiorenza The', '085231778959');

-- --------------------------------------------------------

--
-- Table structure for table `penyelenggara`
--

CREATE TABLE `penyelenggara` (
  `NAMA_P` varchar(50) NOT NULL,
  `ALAMAT_P` varchar(100) NOT NULL,
  `DESKRIPSI_P` varchar(300) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `penyelenggara`
--

INSERT INTO `penyelenggara` (`NAMA_P`, `ALAMAT_P`, `DESKRIPSI_P`) VALUES
('AsiaCommerce', 'Bandung, Jawa Barat', 'Penyelenggara yang mengajarkan tentang bagaimana membuka usaha'),
('Comica Ent', 'Jakarta', 'Penyelenggara event konser stand-up comedy Indonesia'),
('Sahamology', 'TETRA X CHANGE Ruko Nuansa No. 7D. Jln. Raya Pondok Kelapa, Duren Sawit Jakarta Timur', 'Kami adalah layanan edukasi pasar modal. Kami memberikan pemahaman-pemahaman berkaitan dengan analisa pasar modal untuk investor retail');

-- --------------------------------------------------------

--
-- Table structure for table `tiket`
--

CREATE TABLE `tiket` (
  `KATEGORI_TIKET` varchar(50) NOT NULL,
  `JUDUL_EVENT` varchar(100) NOT NULL,
  `DESKRIPSI_TIKET` varchar(50) NOT NULL,
  `HARGA_TIKET` int(11) NOT NULL,
  `KAPASITAS` int(8) NOT NULL,
  `TIKET_TERJUAL` int(8) NOT NULL,
  `AWAL_TIKET` date NOT NULL,
  `AKHIR_TIKET` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tiket`
--

INSERT INTO `tiket` (`KATEGORI_TIKET`, `JUDUL_EVENT`, `DESKRIPSI_TIKET`, `HARGA_TIKET`, `KAPASITAS`, `TIKET_TERJUAL`, `AWAL_TIKET`, `AKHIR_TIKET`) VALUES
('Live Webinar + Recording', 'How To Invest ETF', 'Sudah Termasuk Recording', 200000, 200, 2, '2021-06-04', '2021-06-27'),
('Lucky Entrepreneur', 'Peluang Usaha Tanpa Modal', 'Peluang Usaha Tanpa Modal', 0, 200, 0, '2021-06-06', '2021-06-13'),
('Show 1', 'Komoidoumenoi', 'Show 1 berlangsung dari 15.00-17.00', 600000, 200, 1, '2021-06-04', '2021-08-31'),
('Show 2', 'Komoidoumenoi', 'Show 2 berlangsung dari 19.00-21.00', 600000, 200, 2, '2021-06-04', '2021-08-31');

-- --------------------------------------------------------

--
-- Table structure for table `transaksi_beli_tiket`
--

CREATE TABLE `transaksi_beli_tiket` (
  `ID_TRANS` varchar(30) NOT NULL,
  `USERNAME` varchar(16) NOT NULL,
  `JUDUL_EVENT` varchar(45) NOT NULL,
  `TGL_TRANS` date NOT NULL,
  `JUMLAH_PEMBAYARAN` int(11) NOT NULL,
  `METODE_BAYAR` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `transaksi_beli_tiket`
--

INSERT INTO `transaksi_beli_tiket` (`ID_TRANS`, `USERNAME`, `JUDUL_EVENT`, `TGL_TRANS`, `JUMLAH_PEMBAYARAN`, `METODE_BAYAR`) VALUES
('INV0001', 'dimas.aditya123', 'How To Invest ETF', '2021-06-04', 400000, 'OVO'),
('INV0002', 'dimas.aditya123', 'Komoidoumenoi', '2021-06-04', 1800000, 'OVO');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `detail_trans_beli_tiket`
--
ALTER TABLE `detail_trans_beli_tiket`
  ADD PRIMARY KEY (`ID_TRANS`,`KATEGORI_TIKET`),
  ADD KEY `FK_MEMBELI2` (`KATEGORI_TIKET`);

--
-- Indexes for table `event_acara`
--
ALTER TABLE `event_acara`
  ADD PRIMARY KEY (`JUDUL_EVENT`),
  ADD KEY `FK_DIADAKAN` (`NAMA_P`);

--
-- Indexes for table `pengguna`
--
ALTER TABLE `pengguna`
  ADD PRIMARY KEY (`USERNAME`);

--
-- Indexes for table `penyelenggara`
--
ALTER TABLE `penyelenggara`
  ADD PRIMARY KEY (`NAMA_P`);

--
-- Indexes for table `tiket`
--
ALTER TABLE `tiket`
  ADD PRIMARY KEY (`KATEGORI_TIKET`),
  ADD KEY `FK_MEMILIKI` (`JUDUL_EVENT`);

--
-- Indexes for table `transaksi_beli_tiket`
--
ALTER TABLE `transaksi_beli_tiket`
  ADD PRIMARY KEY (`ID_TRANS`),
  ADD KEY `FK_MELAKUKAN` (`USERNAME`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `detail_trans_beli_tiket`
--
ALTER TABLE `detail_trans_beli_tiket`
  ADD CONSTRAINT `FK_MEMBELI` FOREIGN KEY (`ID_TRANS`) REFERENCES `transaksi_beli_tiket` (`ID_TRANS`),
  ADD CONSTRAINT `FK_MEMBELI2` FOREIGN KEY (`KATEGORI_TIKET`) REFERENCES `tiket` (`KATEGORI_TIKET`);

--
-- Constraints for table `event_acara`
--
ALTER TABLE `event_acara`
  ADD CONSTRAINT `FK_DIADAKAN` FOREIGN KEY (`NAMA_P`) REFERENCES `penyelenggara` (`NAMA_P`);

--
-- Constraints for table `tiket`
--
ALTER TABLE `tiket`
  ADD CONSTRAINT `FK_MEMILIKI` FOREIGN KEY (`JUDUL_EVENT`) REFERENCES `event_acara` (`JUDUL_EVENT`);

--
-- Constraints for table `transaksi_beli_tiket`
--
ALTER TABLE `transaksi_beli_tiket`
  ADD CONSTRAINT `FK_MELAKUKAN` FOREIGN KEY (`USERNAME`) REFERENCES `pengguna` (`USERNAME`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
