--
-- PostgreSQL database dump
--

-- Dumped from database version 9.5.23
-- Dumped by pg_dump version 9.5.23

-- Started on 2020-11-02 21:14:45

SET statement_timeout = 0;
SET lock_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 1 (class 3079 OID 12355)
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- TOC entry 2123 (class 0 OID 0)
-- Dependencies: 1
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 182 (class 1259 OID 16397)
-- Name: Authors; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Authors" (
    "Id" uuid NOT NULL,
    "Email" character(80),
    "Name" character varying
);


ALTER TABLE public."Authors" OWNER TO postgres;

--
-- TOC entry 181 (class 1259 OID 16394)
-- Name: Books; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Books" (
    "Id" uuid NOT NULL,
    fk_author uuid NOT NULL,
    fk_genre uuid,
    "Name" character varying
);


ALTER TABLE public."Books" OWNER TO postgres;

--
-- TOC entry 183 (class 1259 OID 16400)
-- Name: Genres; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Genres" (
    "Id" uuid NOT NULL,
    "Description" character varying,
    "Name" character varying
);


ALTER TABLE public."Genres" OWNER TO postgres;

--
-- TOC entry 2113 (class 0 OID 16397)
-- Dependencies: 182
-- Data for Name: Authors; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Authors" ("Id", "Email", "Name") FROM stdin;
f86c48a4-9330-4532-b60b-c06288c0494e	mauricio@gmail.com                                                              	\N
f86c48a4-9330-4532-b60b-c06288c0494f	jose@gmail.com                                                                  	\N
8a27744e-656d-4e0e-9818-c83b5304964f	matias@gmail.com                                                                	\N
75f9808d-b848-4523-8265-b391e64f3f02	juan@gmail.com                                                                  	\N
3fa85f64-5717-4562-b3fc-2c963f66afa6	swagger@gmail.com                                                               	\N
509e482e-7145-4cca-a351-80adefb89427	\N	Drama
\.


--
-- TOC entry 2112 (class 0 OID 16394)
-- Dependencies: 181
-- Data for Name: Books; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Books" ("Id", fk_author, fk_genre, "Name") FROM stdin;
e6d7c0c0-3204-4818-99dd-4eff17855058	8a27744e-656d-4e0e-9818-c83b5304964f	6c253c19-fab4-49aa-b5c1-4df42888650f	La Sombra
\.


--
-- TOC entry 2114 (class 0 OID 16400)
-- Dependencies: 183
-- Data for Name: Genres; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Genres" ("Id", "Description", "Name") FROM stdin;
6c253c19-fab4-49aa-b5c1-4df42888650f	dramas	\N
eed1f0b7-6b67-4935-8f6a-fded099a83dd	dramas	Drama
3fa85f64-5717-4562-b3fc-2c963f66afa6	string	string
\.


--
-- TOC entry 1991 (class 2606 OID 16432)
-- Name: BookPrimary; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Books"
    ADD CONSTRAINT "BookPrimary" PRIMARY KEY ("Id");


--
-- TOC entry 1995 (class 2606 OID 16419)
-- Name: GenrePrimary; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Genres"
    ADD CONSTRAINT "GenrePrimary" PRIMARY KEY ("Id");


--
-- TOC entry 1993 (class 2606 OID 16404)
-- Name: PrimaryAuhtor; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Authors"
    ADD CONSTRAINT "PrimaryAuhtor" PRIMARY KEY ("Id");


--
-- TOC entry 1996 (class 2606 OID 16410)
-- Name: Authors; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Books"
    ADD CONSTRAINT "Authors" FOREIGN KEY (fk_author) REFERENCES public."Authors"("Id");


--
-- TOC entry 1997 (class 2606 OID 16420)
-- Name: Genres; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Books"
    ADD CONSTRAINT "Genres" FOREIGN KEY (fk_genre) REFERENCES public."Genres"("Id");


--
-- TOC entry 2122 (class 0 OID 0)
-- Dependencies: 6
-- Name: SCHEMA public; Type: ACL; Schema: -; Owner: postgres
--

REVOKE ALL ON SCHEMA public FROM PUBLIC;
REVOKE ALL ON SCHEMA public FROM postgres;
GRANT ALL ON SCHEMA public TO postgres;
GRANT ALL ON SCHEMA public TO PUBLIC;


-- Completed on 2020-11-02 21:14:45

--
-- PostgreSQL database dump complete
--

