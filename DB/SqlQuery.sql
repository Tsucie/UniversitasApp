ALTER TABLE `db_kampus`.`mahasiswa`
ADD COLUMN `mhs_ps_id` INT NOT NULL AFTER `mhs_fks_id`,
ADD COLUMN `mhs_mk_id` INT DEFAULT NULL AFTER `mhs_ps_id`,
ADD CONSTRAINT `fk_mhsDetail_programStudi` FOREIGN KEY (`mhs_ps_id`)
  REFERENCES `db_kampus`.`program_studi` (`ps_id`),
ADD CONSTRAINT `fk_mhsDetail_mataKuliah` FOREIGN KEY (`mhs_mk_id`)
  REFERENCES `db_kampus`.`mata_kuliah` (`mk_id`);