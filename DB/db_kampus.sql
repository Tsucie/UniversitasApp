
-- Setup  MySQL Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- Create Database
CREATE SCHEMA IF NOT EXISTS `db_kampus` DEFAULT CHARACTER SET utf8 COLLATE utf8_bin;
USE `db_kampus`;

-- Create Table

CREATE TABLE IF NOT EXISTS `db_kampus`.`role_type` (
	`rt_id` INT NOT NULL,
	`rt_name` VARCHAR(45) NOT NULL,
	`rt_desc` VARCHAR(255) DEFAULT NULL,
	PRIMARY KEY (`rt_id`),
	UNIQUE KEY `rt_id_UNIQUE` (`rt_id`)
)
ENGINE = InnoDB;

LOCK TABLES `db_kampus`.`role_type` WRITE;
INSERT INTO `db_kampus`.`role_type` VALUES (1,'Principal User','Akun Developer'),(2,'Client User','Akun Pemilik Kampus'),(3,'Site User','Akun Rektor & Wakil Rektor');
UNLOCK TABLES;

CREATE TABLE IF NOT EXISTS `db_kampus`.`role` (
	`r_id` INT NOT NULL,
	`r_rt_id` INT NOT NULL,
	`r_c_id` INT DEFAULT NULL,
	`r_s_id` INT DEFAULT NULL,
	`r_name` VARCHAR(45) NOT NULL,
	`r_desc` VARCHAR(150) DEFAULT NULL,
	`r_rec_status` SMALLINT NOT NULL,
	`r_rec_creator` VARCHAR(45) NOT NULL,
	`r_rec_created` DATETIME NOT NULL,
	`r_rec_updator` VARCHAR(45) DEFAULT NULL,
	`r_rec_updated` DATETIME NOT NULL,
	`r_rec_deletor` VARCHAR(45) DEFAULT NULL,
	`r_rec_deleted` DATETIME NOT NULL,
	PRIMARY KEY (`r_id`,`r_rt_id`),
	UNIQUE KEY (`r_id`),
	CONSTRAINT `fk_role_roleType` FOREIGN KEY (`r_rt_id`)
	REFERENCES `db_kampus`.`role_type` (`rt_id`),
	CONSTRAINT `fk_role_client` FOREIGN KEY (`r_c_id`)
	REFERENCES `db_kampus`.`client` (`c_id`),
	CONSTRAINT `fk_role_site` FOREIGN KEY (`r_s_id`)
	REFERENCES `db_kampus`.`site` (`s_id`)
)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `db_kampus`.`page_group` (
	`pg_id` INT NOT NULL,
	`pg_name` VARCHAR(45) NOT NULL,
	`pg_icon` VARCHAR(45) NOT NULL,
	`pg_order` SMALLINT NOT NULL,
	`pg_rec_status` SMALLINT NOT NULL,
	`pg_rec_creator` VARCHAR(45) NOT NULL,
	`pg_rec_created` DATETIME NOT NULL,
	`pg_rec_updator` VARCHAR(45) DEFAULT NULL,
	`pg_rec_updated` DATETIME NOT NULL,
	`pg_rec_deletor` VARCHAR(45) DEFAULT NULL,
	`pg_rec_deleted` DATETIME NOT NULL,
	PRIMARY KEY (`pg_id`),
	UNIQUE KEY `pg_id_UNIQUE` (`pg_id`)
)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `db_kampus`.`page` (
	`p_id` INT NOT NULL,
	`p_pg_id` INT NOT NULL,
	`p_name` VARCHAR(45) NOT NULL,
	`p_authorization` VARCHAR(45) NOT NULL,
	`p_path` VARCHAR(100) DEFAULT NULL,
	`p_nav_visibility` SMALLINT DEFAULT NULL,
	`p_viewlist_apiUrn` VARCHAR(75) DEFAULT NULL,
	`p_view_apiUrn` VARCHAR(75) DEFAULT NULL,
	`p_view_apiUrn2` VARCHAR(75) DEFAULT NULL,
	`p_add_apiUrn` VARCHAR(75) DEFAULT NULL,
	`p_edit_apiUrn` VARCHAR(75) DEFAULT NULL,
	`p_delete_apiUrn` VARCHAR(75) DEFAULT NULL,
	`p_order` SMALLINT NOT NULL,
	`p_rec_status` SMALLINT NOT NULL,
	`p_rec_creator` VARCHAR(45) NOT NULL,
	`p_rec_created` DATETIME NOT NULL,
	`p_rec_updator` VARCHAR(45) DEFAULT NULL,
	`p_rec_updated` DATETIME NOT NULL,
	`p_rec_deletor` VARCHAR(45) DEFAULT NULL,
	`p_rec_deleted` DATETIME NOT NULL,
	PRIMARY KEY (`p_id`,`p_pg_id`),
	UNIQUE KEY `p_id_UNIQUE` (`p_id`),
	CONSTRAINT `fk_page_pageGroup` FOREIGN KEY (`p_pg_id`)
	REFERENCES `db_kampus`.`page_group` (`pg_id`)
)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `db_kampus`.`page_previledge` (
	`pp_id` INT NOT NULL,
	`pp_p_id` INT NOT NULL,
	`pp_rt_id` INT NOT NULL,
	`pp_view` SMALLINT NOT NULL,
	`pp_add` SMALLINT NOT NULL,
	`pp_edit` SMALLINT NOT NULL,
	`pp_delete` SMALLINT NOT NULL,
	`pp_rec_status` SMALLINT NOT NULL,
	`pp_rec_creator` VARCHAR(45) NOT NULL,
	`pp_rec_created` DATETIME NOT NULL,
	`pp_rec_updator` VARCHAR(45) DEFAULT NULL,
	`pp_rec_updated` DATETIME NOT NULL,
	`pp_rec_deletor` VARCHAR(45) DEFAULT NULL,
	`pp_rec_deleted` DATETIME NOT NULL,
	PRIMARY KEY (`pp_id`,`pp_p_id`,`pp_rt_id`),
	UNIQUE KEY `pp_id_UNIQUE` (`pp_id`),
	CONSTRAINT `fk_pagePreviledge_page` FOREIGN KEY (`pp_p_id`)
	REFERENCES `db_kampus`.`page` (`p_id`),
	CONSTRAINT `fk_pagePreviledge_roleType` FOREIGN KEY (`pp_rt_id`)
	REFERENCES `db_kampus`.`role_type` (`rt_id`)
)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `db_kampus`.`role_previledge` (
	`rp_id` INT NOT NULL,
	`rp_r_id` INT NOT NULL,
	`rp_view` SMALLINT NOT NULL,
	`rp_add` SMALLINT NOT NULL,
	`rp_edit` SMALLINT NOT NULL,
	`rp_delete` SMALLINT NOT NULL,
	`rp_rec_status` SMALLINT NOT NULL,
	`rp_rec_creator` VARCHAR(45) NOT NULL,
	`rp_rec_created` DATETIME NOT NULL,
	`rp_rec_updator` VARCHAR(45) DEFAULT NULL,
	`rp_rec_updated` DATETIME NOT NULL,
	`rp_rec_deletor` VARCHAR(45) DEFAULT NULL,
	`rp_rec_deleted` DATETIME NOT NULL,
	PRIMARY KEY (`rp_id`,`rp_r_id`),
	UNIQUE KEY `rp_id_UNIQUE` (`rp_id`),
	CONSTRAINT `fk_rolePreviledge_role` FOREIGN KEY (`rp_r_id`)
	REFERENCES `db_kampus`.`role` (`r_id`)
)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `db_kampus`.`user_type` (
	`ut_id` INT NOT NULL,
	`ut_name` VARCHAR(45) NOT NULL,
	`ut_desc` VARCHAR(255) DEFAULT NULL,
	PRIMARY KEY (`ut_id`),
	UNIQUE KEY `ut_id_UNIQUE` (`ut_id`)
)
ENGINE = InnoDB;

LOCK TABLES `db_kampus`.`user_type` WRITE;
INSERT INTO `db_kampus`.`user_type` VALUES (1,'Client','Pemilik Kampus'),(2,'Site','Rektor & Wakil Rektor'),(3,'Staff','Dekan, Kaprodi, Administrasi, Dosen, & Karyawan'),(4,'Mahasiswa','Mahasiswa Kampus');
UNLOCK TABLES;

CREATE TABLE IF NOT EXISTS `db_kampus`.`users` (
	`u_id` INT NOT NULL,
	`u_ut_id` INT NOT NULL,
	`u_r_id` INT DEFAULT NULL,
	`u_username` VARCHAR(45) NOT NULL,
	`u_password` VARCHAR(45) NOT NULL,
	`u_login_time` DATETIME NOT NULL,
	`u_logout_time` DATETIME NOT NULL,
	`u_login_status` SMALLINT NOT NULL,
	`u_rec_status` SMALLINT NOT NULL,
	`u_rec_creator` VARCHAR(45) NOT NULL,
	`u_rec_created` DATETIME NOT NULL,
	`u_rec_updator` VARCHAR(45) DEFAULT NULL,
	`u_rec_updated` DATETIME DEFAULT NULL,
	`u_rec_deletor` VARCHAR(45) DEFAULT NULL,
	`u_rec_deleted` DATETIME DEFAULT NULL,
	PRIMARY KEY (`u_id`, `u_ut_id`),
	UNIQUE KEY `u_id_UNIQUE` (`u_id`),
	UNIQUE KEY `u_username_UNIQUE` (`u_username`),
	CONSTRAINT `fk_users_userType` FOREIGN KEY (`u_ut_id`)
	REFERENCES `db_kampus`.`user_type` (`ut_id`),
	CONSTRAINT `fk_users_role` FOREIGN KEY (`u_r_id`)
	REFERENCES `db_kampus`.`role` (`u_r_id`)
)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `db_kampus`.`user_photo` (
	`up_id` INT NOT NULL,
	`up_u_id` INT NOT NULL,
	`up_photo` BLOB NOT NULL,
	`up_filename` VARCHAR(45) NOT NULL,
	`up_rec_status` SMALLINT(6) NOT NULL,
	PRIMARY KEY (`up_id`, `up_u_id`),
	CONSTRAINT `fk_userPhoto_users` FOREIGN KEY (`up_u_id`)
	REFERENCES `db_kampus`.`users` (`u_id`)
)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `db_kampus`.`client` (
	`c_id` INT NOT NULL,
    `c_u_id` INT NOT NULL,
    `c_code` VARCHAR(45) NOT NULL,
    `c_name` VARCHAR(45) NOT NULL,
    `c_remark` VARCHAR(150) DEFAULT NULL,
    PRIMARY KEY (`c_id`, `c_u_id`),
    UNIQUE KEY `c_id_UNIQUE` (`c_id`),
    CONSTRAINT `fk_client_users` FOREIGN KEY (`c_u_id`)
    REFERENCES `db_kampus`.`users` (`u_id`)
)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `db_kampus`.`site` (
	`s_id` INT NOT NULL,
	`s_u_id` INT NOT NULL,
	`s_c_id` INT DEFAULT NULL,
	`s_fullname` VARCHAR(100) NOT NULL,
	`s_nik` VARCHAR(20) NOT NULL,
	`s_address` VARCHAR(255) NOT NULL,
	`s_province` VARCHAR(45) NOT NULL,
	`s_city` VARCHAR(45) NOT NULL,
	`s_birthplace` VARCHAR(45) NOT NULL,
	`s_birthdate` DATE NOT NULL,
	`s_gender` VARCHAR(20) NOT NULL,
	`s_religion` VARCHAR(45) NOT NULL,
	`s_state` VARCHAR(45) NOT NULL,
	`s_email` VARCHAR(45) NOT NULL,
	`s_stat` SMALLINT NOT NULL,
	`s_contact` VARCHAR(20) DEFAULT NULL,
	PRIMARY KEY (`s_id`,`s_u_id`),
	UNIQUE KEY `s_id_UNIQUE` (`s_id`),
	CONSTRAINT `fk_site_users` FOREIGN KEY (`s_u_id`)
	REFERENCES `db_kampus`.`users` (`u_id`),
	CONSTRAINT `fk_site_client` FOREIGN KEY (`s_c_id`)
	REFERENCES `db_kampus`.`client` (`c_id`)
)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `db_kampus`.`fakultas` (
	`fks_id` INT NOT NULL AUTO_INCREMENT,
	`fks_name` VARCHAR(45) NOT NULL,
	`fks_desc` VARCHAR(255) DEFAULT NULL,
	PRIMARY KEY (`fks_id`),
	UNIQUE KEY `fks_id_UNIQUE` (`fks_id`)
)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `db_kampus`.`staff_category` (
	`sc_id` INT NOT NULL,
	`sc_name` VARCHAR(45) NOT NULL,
	`sc_desc` VARCHAR(150) DEFAULT NULL,
	PRIMARY KEY (`sc_id`),
	UNIQUE KEY `sc_id_UNIQUE` (`sc_id`)
)
ENGINE = InnoDB;

LOCK TABLES `db_kampus`.`staff_category` WRITE;
INSERT INTO `db_kampus`.`staff_category` VALUES (1,'Dekan','Dekan Kampus'),(2,'Kaprodi','Kaprodi Kampus'),(3,'Dosen','Dosen Kampus'),(4,'Karyawan','Karyawan Kampus');
UNLOCK TABLES;

CREATE TABLE IF NOT EXISTS `db_kampus`.`staff` (
	`stf_id` INT NOT NULL,
    `stf_u_id` INT NOT NULL,
	`stf_sc_id` INT NOT NULL,
    `stf_fks_id` INT DEFAULT NULL,
    `stf_ps_id` INT DEFAULT NULL,
    `stf_mk_id` INT DEFAULT NULL,
	`stf_fullname` VARCHAR(100) NOT NULL,
	`stf_nik` VARCHAR(20) NOT NULL,
	`stf_address` VARCHAR(255) NOT NULL,
	`stf_province` VARCHAR(45) NOT NULL,
	`stf_city` VARCHAR(45) NOT NULL,
	`stf_birthplace` VARCHAR(45) NOT NULL,
	`stf_birthdate` DATE NOT NULL,
	`stf_gender` VARCHAR(20) NOT NULL,
	`stf_religion` VARCHAR(45) NOT NULL,
	`stf_state` VARCHAR(45) NOT NULL,
	`stf_email` VARCHAR(45) NOT NULL,
	`stf_stat` SMALLINT NOT NULL,
	`stf_contact` VARCHAR(20) DEFAULT NULL,
	PRIMARY KEY (`stf_id`, `stf_u_id`, `stf_sc_id`, `stf_fks_id`),
	UNIQUE KEY `stf_id_UNIQUE` (`stf_id`),
	UNIQUE KEY `stf_nik_UNIQUE` (`stf_nik`),
    CONSTRAINT `fk_staffDetail_users` FOREIGN KEY (`stf_u_id`)
    REFERENCES `db_kampus`.`users` (`u_id`),
	CONSTRAINT `fk_staffDetail_staffCategory` FOREIGN KEY (`stf_sc_id`)
	REFERENCES `db_kampus`.`staff_category` (`sc_id`),
    CONSTRAINT `fk_staffDetail_fakultas` FOREIGN KEY (`stf_fks_id`)
	REFERENCES `db_kampus`.`fakultas` (`fks_id`),
	CONSTRAINT `fk_staffDetail_programStudi` FOREIGN KEY (`stf_ps_id`)
	REFERENCES `db_kampus`.`program_studi` (`ps_id`),
	CONSTRAINT `fk_staffDetail_mataKuliah` FOREIGN KEY (`stf_mk_id`)
	REFERENCES `db_kampus`.`mata_kuliah` (`mk_id`)
)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `db_kampus`.`mahasiswa` (
	`mhs_id` INT NOT NULL,
    `mhs_u_id` INT NOT NULL,
    `mhs_fks_id` INT NOT NULL,
	`mhs_fullname` VARCHAR(100) NOT NULL,
	`mhs_nim` VARCHAR(20) NOT NULL,
	`mhs_kelas` VARCHAR(20) NOT NULL,
	`mhs_address` VARCHAR(255) NOT NULL,
	`mhs_province` VARCHAR(45) NOT NULL,
	`mhs_city` VARCHAR(45) NOT NULL,
	`mhs_birthplace` VARCHAR(45) NOT NULL,
	`mhs_birthdate` DATE NOT NULL,
	`mhs_gender` VARCHAR(20) NOT NULL,
	`mhs_religion` VARCHAR(45) NOT NULL,
	`mhs_state` VARCHAR(45) NOT NULL,
	`mhs_email` VARCHAR(45) NOT NULL,
	`mhs_stat` SMALLINT NOT NULL,
	`mhs_contact` VARCHAR(20) DEFAULT NULL,
	PRIMARY KEY (`mhs_id`, `mhs_u_id`, `mhs_fks_id`),
	UNIQUE KEY `mhs_id_UNIQUE` (`mhs_id`),
	UNIQUE KEY `mhs_nim_UNIQUE` (`mhs_nim`),
    CONSTRAINT `fk_mhsDetail_users` FOREIGN KEY (`mhs_u_id`)
    REFERENCES `db_kampus`.`users` (`u_id`),
    CONSTRAINT `fk_mhsDetail_fakultas` FOREIGN KEY (`mhs_fks_id`)
    REFERENCES `db_kampus`.`fakultas` (`fks_id`)
)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `db_kampus`.`payment` (
	`pi_id` INT NOT NULL,
	`pi_mhs_id` INT NOT NULL,
	`pi_code` VARCHAR(20) NOT NULL,
	`pi_name` VARCHAR(45) NOT NULL,
	`pi_value` INT NOT NULL,
	`pi_stat` SMALLINT NOT NULL,
	`pi_date` DATETIME NOT NULL,
	`pi_channel` VARCHAR(45) NOT NULL,
	`pi_desc` VARCHAR(150) DEFAULT NULL,
	`pi_rec_status` SMALLINT NOT NULL,
	`pi_rec_creator` VARCHAR(45) NOT NULL,
	`pi_rec_created` DATETIME NOT NULL,
	`pi_rec_updator` VARCHAR(45) DEFAULT NULL,
	`pi_rec_updated` DATETIME DEFAULT NULL,
	`pi_rec_deletor` VARCHAR(45) DEFAULT NULL,
	`pi_rec_deleted` DATETIME DEFAULT NULL,
	PRIMARY KEY (`pi_id`, `pi_mhs_id`, `pi_mhs_u_id`),
	UNIQUE KEY `pi_id_UNIQUE` (`pi_id`),
	UNIQUE KEY `pi_code_UNIQUE` (`pi_code`),
	CONSTRAINT `fk_payment_mahasiswa` FOREIGN KEY (`pi_mhs_id`)
	REFERENCES `db_kampus`.`mahasiswa` (`mhs_id`)
)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `db_kampus`.`salary` (
	`sal_id` INT NOT NULL,
	`sal_stf_id` INT DEFAULT NULL,
	`sal_s_id` INT DEFAULT NULL,
	`sal_code` VARCHAR(20) NOT NULL,
	`sal_value` INT NOT NULL,
	`sal_date` DATE DEFAULT NULL,
	`sal_channel` VARCHAR(45) DEFAULT NULL,
	`sal_desc` VARCHAR(150) DEFAULT NULL,
	`sal_rec_status` SMALLINT NOT NULL,
	`sal_rec_creator` VARCHAR(45) NOT NULL,
	`sal_rec_created` DATETIME NOT NULL,
	`sal_rec_updator` VARCHAR(45) DEFAULT NULL,
	`sal_rec_updated` DATETIME DEFAULT NULL,
	`sal_rec_deletor` VARCHAR(45) DEFAULT NULL,
	`sal_rec_deleted` DATETIME DEFAULT NULL,
	PRIMARY KEY (`sal_id`),
	UNIQUE KEY `sal_id_UNIQUE` (`sal_id`),
	UNIQUE KEY `sal_code_UNIQUE` (`sal_code`),
	CONSTRAINT `fk_salary_staff` FOREIGN KEY (`sal_stf_id`)
	REFERENCES `db_kampus`.`staff` (`stf_id`),
	CONSTRAINT `fk_salary_site` FOREIGN KEY (`sal_s_id`)
	REFERENCES `db_kampus`.`site` (`s_id`)
)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `db_kampus`.`program_studi` (
	`ps_id` INT NOT NULL,
    `ps_fks_id` INT NOT NULL,
    `ps_name` VARCHAR(45) NOT NULL,
    `ps_desc` VARCHAR(255) DEFAULT NULL,
    PRIMARY KEY (`ps_id`,`ps_fks_id`),
    UNIQUE KEY (`ps_id`),
    CONSTRAINT `fk_programStudy_fakultas` FOREIGN KEY (`ps_fks_id`)
    REFERENCES `db_kampus`.`fakultas` (`fks_id`)
)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `db_kampus`.`semester` (
	`sm_id` INT NOT NULL,
    `sm_name` VARCHAR(45) NOT NULL,
    `sm_code` VARCHAR(45) NOT NULL,
    `sm_val` INT NOT NULL,
    `sm_desc` VARCHAR(255) DEFAULT NULL,
    PRIMARY KEY (`sm_id`),
    UNIQUE KEY (`sm_id`)
)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `db_kampus`.`mata_kuliah` (
	`mk_id` INT NOT NULL,
	`mk_ps_id` INT NOT NULL,
    `mk_sm_id` INT NOT NULL,
	`mk_sks` INT NOT NULL,
	`mk_mutu` INT NOT NULL,
	`mk_code` VARCHAR(12) NOT NULL,
	`mk_name` VARCHAR(45) NOT NULL,
	`mk_semester` VARCHAR(45) NOT NULL,
	`mk_desc` VARCHAR(255) DEFAULT NULL,
	PRIMARY KEY (`mk_id`, `mk_ps_id`,`mk_sm_id`),
	UNIQUE KEY `mk_id_UNIQUE` (`mk_id`),
	UNIQUE KEY `mk_code_UNIQUE` (`mk_code`),
	CONSTRAINT `fk_mataKuliah_programStudi` FOREIGN KEY (`mk_ps_id`)
	REFERENCES `db_kampus`.`program_studi` (`ps_id`),
    CONSTRAINT `fk_mataKuliah_semester` FOREIGN KEY (`mk_sm_id`)
    REFERENCES `db_kampus`.`semester` (`sm_id`)
)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `db_kampus`.`nilai_category` (
	`nc_id` INT NOT NULL,
	`nc_name` VARCHAR(45) NOT NULL,
	`nc_desc` VARCHAR(100) DEFAULT NULL,
	PRIMARY KEY (`nc_id`)
)
ENGINE = InnoDB;

LOCK TABLES `db_kampus`.`nilai_category` WRITE;
INSERT INTO `db_kampus`.`nilai_category` VALUES (1,'Nilai Absen','Nilai Absen bernilai 10%'),(2,'Nilai Tugas','Nilai Tugas bernilai 20%'),(3,'Nilai Ujian Tengah Semester','Nilai UTS bernilai 30%'),(4,'Nilai Ujian Akhir Semester','Nilai UAS bernilai 40%');
UNLOCK TABLES;

CREATE TABLE IF NOT EXISTS `db_kampus`.`ip_semester` (
	`ips_id` INT NOT NULL,
    `ips_sm_id` INT NOT NULL,
	`ips_value` DECIMAL NOT NULL,
	`ips_desc` VARCHAR(100) DEFAULT NULL,
	PRIMARY KEY (`ips_id`,`ips_sm_id`),
    UNIQUE KEY (`ips_id`),
    CONSTRAINT `fk_ipSemester_semester` FOREIGN KEY (`ips_sm_id`)
    REFERENCES `db_kampus`.`semester` (`sm_id`)
)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `db_kampus`.`ip_komulatif` (
	`ipk_id` INT NOT NULL,
	`ipk_value` DECIMAL NOT NULL,
	`ipk_desc` VARCHAR(100) DEFAULT NULL,
	PRIMARY KEY (`ipk_id`)
)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `db_kampus`.`nilai` (
	`n_id` INT NOT NULL,
	`n_mk_id` INT NOT NULL,
	`n_nc_id` INT NOT NULL,
	`n_ips_id` INT DEFAULT NULL,
	`n_ipk_id` INT DEFAULT NULL,
	`n_value` DECIMAL NOT NULL,
	`n_name` VARCHAR(45) NOT NULL,
	`n_desc` VARCHAR(100) DEFAULT NULL,
	PRIMARY KEY (`n_id`, `n_mk_id`, `n_nc_id`),
	CONSTRAINT `fk_nilai_mataKuliah` FOREIGN KEY (`n_mk_id`)
	REFERENCES `db_kampus`.`mata_kuliah` (`mk_id`),
	CONSTRAINT `fk_nilai_nilaiCategory` FOREIGN KEY (`n_nc_id`)
	REFERENCES `db_kampus`.`nilai_category` (`nc_id`),
	CONSTRAINT `fk_nilai_ipSemester` FOREIGN KEY (`n_ips_id`)
	REFERENCES `db_kampus`.`ip_semester` (`ips_id`),
	CONSTRAINT `fk_nilai_ipKomulatif` FOREIGN KEY (`n_ipk_id`)
	REFERENCES `db_kampus`.`ip_komulatif` (`ipk_id`)
)
ENGINE = InnoDB;

-- End Setup MySQL Engineering
SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;