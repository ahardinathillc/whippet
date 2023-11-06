using System;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager
{
    /// <summary>
    /// Provides constants for database tables, columns, and schemas. This class cannot be inherited.
    /// </summary>
    internal static class MultichannelOrderManagerDatabaseConstants
    {
        /// <summary>
        /// Represents all mapped tables in M.O.M. This class cannot be inherited.
        /// </summary>
        internal static class Tables
        {
            public const string CTYPE1 = nameof(CTYPE1);
            public const string CTYPE2 = nameof(CTYPE2);
            public const string CTYPE3 = nameof(CTYPE3);
            public const string CUST = nameof(CUST);
            public const string COUNTRY = nameof(COUNTRY);
            public const string COUNTY = nameof(COUNTY);
            public const string ITEMS = nameof(ITEMS);
            public const string ORDERS = "CMS";
            public const string STOCK = nameof(STOCK);
            public const string SUPPLIER = nameof(SUPPLIER);
            public const string CUSTRELA = nameof(CUSTRELA);
            public const string WAREHOUS = nameof(WAREHOUS);
            public const string STATE = nameof(STATE);
            public const string ZIP = nameof(ZIP);
        }

        /// <summary>
        /// Provides access to tables, views, procedures, and other objects that pertain specifically to data exports in M.O.M. These objects may or may not reside on the same server or database as the parent M.O.M. database. This class cannot be inherited.
        /// </summary>
        internal static class Exports
        {
            /// <summary>
            /// Represents all views available in the export domain. This class cannot be inherited.
            /// </summary>
            internal static class Views
            {
                public const string FlattenedTaxRateExport = "MOM_taxrates";
            }

            /// <summary>
            /// Represents all mapped columns in M.O.M. export domain objects. This class cannot be inherited.
            /// </summary>
            internal static class Columns
            {
                public const string RATE = "rate";
                public const string ZIPCODE = "zipcode";
                public const string STATE_ID = "state_id";
                public const string COUNTRY_ID = "country_id";
                public const string TAX_SHIPPING = "taxShipping";
                public const string TAX_SAAS = "taxSaaS";
            }
        }

        /// <summary>
        /// Represents all mapped columns in M.O.M. This class cannot be inherited.
        /// </summary>
        internal static class Columns
        {
            public const string CTYPE = nameof(CTYPE);
            public const string CTYPE2 = nameof(CTYPE2);
            public const string CTYPE3 = nameof(CTYPE3);

            public const string DESC1 = nameof(DESC1);

            public const string CTYPE_ID = nameof(CTYPE_ID);
            public const string CTYPE2_ID = nameof(CTYPE2_ID);
            public const string CTYPE3_ID = nameof(CTYPE3_ID);

            public const string LU_BY = nameof(LU_BY);
            public const string LU_ON = nameof(LU_ON);

            // CUST table
            public const string CUSTNUM = nameof(CUSTNUM);
            public const string ALTNUM = nameof(ALTNUM);
            public const string CUSTTYPE = nameof(CUSTTYPE);
            public const string LASTNAME = nameof(LASTNAME);
            public const string FIRSTNAME = nameof(FIRSTNAME);
            public const string COMPANY = nameof(COMPANY);
            public const string ADDR = nameof(ADDR);
            public const string ADDR2 = nameof(ADDR2);
            public const string CITY = nameof(CITY);
            public const string STATE = nameof(STATE);
            public const string ZIPCODE = nameof(ZIPCODE);
            public const string COUNTRY = nameof(COUNTRY);
            public const string PHONE = nameof(PHONE);
            public const string PHONE2 = nameof(PHONE2);
            public const string ORIG_AD = nameof(ORIG_AD);
            public const string LAST_AD = nameof(LAST_AD);
            public const string CATCOUNT = nameof(CATCOUNT);
            public const string ODR_DATE = nameof(ODR_DATE);
            public const string PAYMETHOD = nameof(PAYMETHOD);
            public const string CARDNUM = nameof(CARDNUM);
            public const string CARDTYPE = nameof(CARDTYPE);
            public const string EXP = nameof(EXP);
            public const string SHIPLIST = nameof(SHIPLIST);
            public const string EXPIRED = nameof(EXPIRED);
            public const string BADCHECK = nameof(BADCHECK);
            public const string ORDERREC = nameof(ORDERREC);
            public const string NET = nameof(NET);
            public const string GROSS = nameof(GROSS);
            public const string ORD_FREQ = nameof(ORD_FREQ);
            public const string COMMENT = nameof(COMMENT);
            public const string CUSTBAL = nameof(CUSTBAL);
            public const string CUSTREF = nameof(CUSTREF);
            public const string DISCOUNT = nameof(DISCOUNT);
            public const string EXEMPT = nameof(EXEMPT);
            public const string AR_BALANCE = nameof(AR_BALANCE);
            public const string CREDIT_LIM = nameof(CREDIT_LIM);
            public const string DISCT_DAYS = nameof(DISCT_DAYS);
            public const string DUE_DAYS = nameof(DUE_DAYS);
            public const string DISCT_PCT = nameof(DISCT_PCT);
            public const string PROMO_BAL = nameof(PROMO_BAL);
            public const string COMMENT2 = nameof(COMMENT2);
            public const string SALES_ID = nameof(SALES_ID);
            public const string NOMAIL = nameof(NOMAIL);
            public const string BELONGNUM = nameof(BELONGNUM);
            public const string CARROUTE = nameof(CARROUTE);
            public const string DELPOINT = nameof(DELPOINT);
            public const string NCOACHANGE = nameof(NCOACHANGE);
            public const string ENTRYDATE = nameof(ENTRYDATE);
            public const string SEARCHCOMP = nameof(SEARCHCOMP);
            public const string EMAIL = nameof(EMAIL);
            public const string N_EXEMPT = nameof(N_EXEMPT);
            public const string TAX_ID = nameof(TAX_ID);
            public const string CASHONLY = nameof(CASHONLY);
            public const string SALU = nameof(SALU);
            public const string HONO = nameof(HONO);
            public const string TITLE = nameof(TITLE);
            public const string NOEMAIL = nameof(NOEMAIL);
            public const string PASSWORD = nameof(PASSWORD);
            public const string RFM = nameof(RFM);
            public const string POINTS = nameof(POINTS);
            public const string NORENT = nameof(NORENT);
            public const string ADDR_TYPE = nameof(ADDR_TYPE);
            public const string WEB = nameof(WEB);
            public const string EXTENSION = nameof(EXTENSION);
            public const string EXTENSION2 = nameof(EXTENSION2);
            public const string DATE_LIMIT = nameof(DATE_LIMIT);
            public const string START_DATE = nameof(START_DATE);
            public const string END_DATE = nameof(END_DATE);
            public const string FROM_MONTH = nameof(FROM_MONTH);
            public const string FROM_DAY = nameof(FROM_DAY);
            public const string TO_MONTH = nameof(TO_MONTH);
            public const string TO_DAY = nameof(TO_DAY);
            public const string ADDRISSAME = nameof(ADDRISSAME);
            public const string LASTUSER = nameof(LASTUSER);
            public const string NOPOINTS = nameof(NOPOINTS);
            public const string UPSCOMDELV = nameof(UPSCOMDELV);
            public const string FREE_SHIP = nameof(FREE_SHIP);
            public const string PREF_PAY = nameof(PREF_PAY);
            public const string PREF_SHIP = nameof(PREF_SHIP);
            public const string ADDR3 = nameof(ADDR3);
            public const string VALADDR = nameof(VALADDR);
            public const string VALDATE = nameof(VALDATE);
            public const string SOUNDLNAME = nameof(SOUNDLNAME);
            public const string ADDREXPIRE = nameof(ADDREXPIRE);
            public const string ACVMEDATE = nameof(ACVMEDATE);
            public const string MODI_USER = nameof(MODI_USER);
            public const string MODI_DATE = nameof(MODI_DATE);
            public const string ACT_DATE = nameof(ACT_DATE);
            public const string DSCTSTDATE = nameof(DSCTSTDATE);
            public const string DSCTENDATE = nameof(DSCTENDATE);
            public const string PREFWARE = nameof(PREFWARE);
            public const string BESTTTC = nameof(BESTTTC);
            public const string FRAUD = nameof(FRAUD);
            public const string NOCALL = nameof(NOCALL);
            public const string TAX_ID2 = nameof(TAX_ID2);
            public const string EMAILDEF = nameof(EMAILDEF);
            public const string EMAILPREF = nameof(EMAILPREF);
            public const string NOFAX = nameof(NOFAX);
            public const string SERVER = nameof(SERVER);
            public const string ROOT = nameof(ROOT);
            public const string STORES = nameof(STORES);
            public const string C_EXEMPT = nameof(C_EXEMPT);
            public const string I_EXEMPT = nameof(I_EXEMPT);
            public const string CUST_TERMS = nameof(CUST_TERMS);
            public const string AUTOSUPPORT = nameof(AUTOSUPPORT);
            public const string TFEXEMPT = nameof(TFEXEMPT);

            // country
            public const string NAME = nameof(NAME);
            public const string NTAXR = nameof(NTAXR);
            public const string PHONEMASK = nameof(PHONEMASK);
            public const string TAX_CLASSA = nameof(TAX_CLASSA);
            public const string TAX_CLASSB = nameof(TAX_CLASSB);
            public const string TAX_CLASSC = nameof(TAX_CLASSC);
            public const string TAX_CLASSD = nameof(TAX_CLASSD);
            public const string TAX_CLASSE = nameof(TAX_CLASSE);
            public const string TAXSHIP = nameof(TAXSHIP);
            public const string ISO2 = nameof(ISO2);
            public const string ISO3 = nameof(ISO3);
            public const string ISONUM = nameof(ISONUM);
            public const string RATECLASSA = nameof(RATECLASSA);
            public const string RATECLASSB = nameof(RATECLASSB);
            public const string RATECLASSC = nameof(RATECLASSC);
            public const string RATECLASSD = nameof(RATECLASSD);
            public const string RATECLASSE = nameof(RATECLASSE);
            public const string WAREHOUSE = nameof(WAREHOUSE);
            public const string N_LCAPA = nameof(N_LCAPA);
            public const string N_LCAPB = nameof(N_LCAPB);
            public const string N_LCAPC = nameof(N_LCAPC);
            public const string N_LCAPD = nameof(N_LCAPD);
            public const string N_LCAPE = nameof(N_LCAPE);
            public const string N_LTAXITA = nameof(N_LTAXITA);
            public const string N_LTAXITB = nameof(N_LTAXITB);
            public const string N_LTAXITC = nameof(N_LTAXITC);
            public const string N_LTAXITD = nameof(N_LTAXITD);
            public const string N_LTAXITE = nameof(N_LTAXITE);
            public const string N_NCAPA = nameof(N_NCAPA);
            public const string N_NCAPB = nameof(N_NCAPB);
            public const string N_NCAPC = nameof(N_NCAPC);
            public const string N_NCAPD = nameof(N_NCAPD);
            public const string N_NCAPE = nameof(N_NCAPE);
            public const string N_NTAXITA = nameof(N_NTAXITA);
            public const string N_NTAXITB = nameof(N_NTAXITB);
            public const string N_NTAXITC = nameof(N_NTAXITC);
            public const string N_NTAXITD = nameof(N_NTAXITD);
            public const string N_NTAXITE = nameof(N_NTAXITE);
            public const string NONTAXBOX = nameof(NONTAXBOX);
            public const string NTAXTHRESA = nameof(NTAXTHRESA);
            public const string NTAXTHRESB = nameof(NTAXTHRESB);
            public const string NTAXTHRESC = nameof(NTAXTHRESC);
            public const string NTAXTHRESD = nameof(NTAXTHRESD);
            public const string NTAXTHRESE = nameof(NTAXTHRESE);
            public const string TAXHAND = nameof(TAXHAND);
            public const string COUNTRY_ID = nameof(COUNTRY_ID);
            public const string CTAXTHRESA = nameof(CTAXTHRESA);
            public const string CTAXTHRESB = nameof(CTAXTHRESB);
            public const string CTAXTHRESC = nameof(CTAXTHRESC);
            public const string CTAXTHRESD = nameof(CTAXTHRESD);
            public const string CTAXTHRESE = nameof(CTAXTHRESE);

            // county

            public const string COUNTY = nameof(COUNTY);
            public const string FIPS = nameof(FIPS);
            public const string T_Z = nameof(T_Z);
            public const string CTAXR = nameof(CTAXR);
            public const string PRESENCE = nameof(PRESENCE);
            public const string CODE1 = nameof(CODE1);
            public const string UPDATED = nameof(UPDATED);
            public const string MSA = nameof(MSA);
            public const string COUNTY_ID = nameof(COUNTY_ID);
            public const string C_LCAPA = nameof(C_LCAPA);
            public const string C_LCAPB = nameof(C_LCAPB);
            public const string C_LCAPC = nameof(C_LCAPC);
            public const string C_LCAPD = nameof(C_LCAPD);
            public const string C_LCAPE = nameof(C_LCAPE);
            public const string C_LTAXITA = nameof(C_LTAXITA);
            public const string C_LTAXITB = nameof(C_LTAXITB);
            public const string C_LTAXITC = nameof(C_LTAXITC);
            public const string C_LTAXITD = nameof(C_LTAXITD);
            public const string C_LTAXITE = nameof(C_LTAXITE);
            public const string C_NCAPA = nameof(C_NCAPA);
            public const string C_NCAPB = nameof(C_NCAPB);
            public const string C_NCAPC = nameof(C_NCAPC);
            public const string C_NCAPD = nameof(C_NCAPD);
            public const string C_NCAPE = nameof(C_NCAPE);
            public const string C_NTAXITA = nameof(C_NTAXITA);
            public const string C_NTAXITB = nameof(C_NTAXITB);
            public const string C_NTAXITC = nameof(C_NTAXITC);
            public const string C_NTAXITD = nameof(C_NTAXITD);
            public const string C_NTAXITE = nameof(C_NTAXITE);

            // items

            public const string ADVERT = nameof(ADVERT);
            public const string ADDLCOST = nameof(ADDLCOST);
            public const string ALT_ITEMID = nameof(ALT_ITEMID);
            public const string BHEIGHT = nameof(BHEIGHT);
            public const string BILLED = nameof(BILLED);
            public const string BINMODIFY = nameof(BINMODIFY);
            public const string BIN_ID = nameof(BIN_ID);
            public const string BLENGTH = nameof(BLENGTH);
            public const string BOX = nameof(BOX);
            public const string BWIDTH = nameof(BWIDTH);
            public const string CATCODE = nameof(CATCODE);
            public const string CERTID = nameof(CERTID);
            public const string COMMITDATE = nameof(COMMITDATE);
            public const string CTAXCAP = nameof(CTAXCAP);
            public const string CTAXCLASS = nameof(CTAXCLASS);
            public const string CTAXCODE = nameof(CTAXCODE);
            public const string CTAXRATE = nameof(CTAXRATE);
            public const string CTAXTHRES = nameof(CTAXTHRES);
            public const string CUSTOMINFO = nameof(CUSTOMINFO);
            public const string C_NONTAX = nameof(C_NONTAX);
            public const string DROPSHIP = nameof(DROPSHIP);
            public const string EXTENDDESC = nameof(EXTENDDESC);
            public const string GCADDVALUE = nameof(GCADDVALUE);
            public const string GCERTPRINT = nameof(GCERTPRINT);
            public const string INPART = nameof(INPART);
            public const string INT_EXT = nameof(INT_EXT);
            public const string INVENT_ID = nameof(INVENT_ID);
            public const string ITAXCAP = nameof(ITAXCAP);
            public const string ITAXCLASS = nameof(ITAXCLASS);
            public const string ITAXCODE = nameof(ITAXCODE);
            public const string ITAXRATE = nameof(ITAXRATE);
            public const string ITAXTHRES = nameof(ITAXTHRES);
            public const string ITEM = nameof(ITEM);
            public const string ITEM_ID = nameof(ITEM_ID);
            public const string ITEM_STATE = nameof(ITEM_STATE);
            public const string IT_SDATE = nameof(IT_SDATE);
            public const string IT_UNCOST = nameof(IT_UNCOST);
            public const string IT_UNLIST = nameof(IT_UNLIST);
            public const string I_NONTAX = nameof(I_NONTAX);
            public const string NEEDSCAN = nameof(NEEDSCAN);
            public const string NODSCT = nameof(NODSCT);
            public const string NONPRODUCT = nameof(NONPRODUCT);
            public const string NONTAX = nameof(NONTAX);
            public const string NTAXCAP = nameof(NTAXCAP);
            public const string NTAXCLASS = nameof(NTAXCLASS);
            public const string NTAXCODE = nameof(NTAXCODE);
            public const string NTAXRATE = nameof(NTAXRATE);
            public const string NTAXTHRES = nameof(NTAXTHRES);
            public const string N_NONTAX = nameof(N_NONTAX);
            public const string ORDERED = nameof(ORDERED);
            public const string ORDERNO = nameof(ORDERNO);
            public const string OVERSIZE2 = nameof(OVERSIZE2);
            public const string OVERSIZE3 = nameof(OVERSIZE3);
            public const string OVERSIZED = nameof(OVERSIZED);
            public const string PACKED = nameof(PACKED);
            public const string PICKED = nameof(PICKED);
            public const string PICKSCAN = nameof(PICKSCAN);
            public const string PMMSTATUS = nameof(PMMSTATUS);
            public const string PONUMBER = nameof(PONUMBER);
            public const string POPENTRY = nameof(POPENTRY);
            public const string PRICECHANG = nameof(PRICECHANG);
            public const string PTS_RDEEMD = nameof(PTS_RDEEMD);
            public const string QUANTB = nameof(QUANTB);
            public const string QUANTF = nameof(QUANTF);
            public const string QUANTO = nameof(QUANTO);
            public const string QUANTP = nameof(QUANTP);
            public const string QUANTS = nameof(QUANTS);
            public const string QUOTATION = nameof(QUOTATION);
            public const string RETITEM = nameof(RETITEM);
            public const string R_CODE = nameof(R_CODE);
            public const string SEQ = nameof(SEQ);
            public const string SHIP_FROM = nameof(SHIP_FROM);
            public const string SHIP_TO = nameof(SHIP_TO);
            public const string SHIP_VIA = nameof(SHIP_VIA);
            public const string SHIP_WHEN = nameof(SHIP_WHEN);
            public const string STAXCAP = nameof(STAXCAP);
            public const string STAXCLASS = nameof(STAXCLASS);
            public const string STAXCODE = nameof(STAXCODE);
            public const string STAXRATE = nameof(STAXRATE);
            public const string STAXTHRES = nameof(STAXTHRES);
            public const string SUP_EDATE = nameof(SUP_EDATE);
            public const string SUP_LICNUM = nameof(SUP_LICNUM);
            public const string SUP_ODATE = nameof(SUP_ODATE);
            public const string SUP_SDATE = nameof(SUP_SDATE);
            public const string TAXMODIFY = nameof(TAXMODIFY);
            public const string TAXSERVICE = nameof(TAXSERVICE);
            public const string TRANS_ID = nameof(TRANS_ID);
            public const string VATAMT = nameof(VATAMT);
            public const string VATINCL = nameof(VATINCL);
            public const string VATLIST = nameof(VATLIST);
            public const string WAREMODIFY = nameof(WAREMODIFY);

            // stock items

            public const string NUMBER = nameof(NUMBER);
            public const string DESC2 = nameof(DESC2);
            public const string UNITS = nameof(UNITS);
            public const string LOW = nameof(LOW);
            public const string UNITWEIGHT = nameof(UNITWEIGHT);
            public const string UNCOST = nameof(UNCOST);
            public const string PRICE1 = nameof(PRICE1);
            public const string BOUNITS = nameof(BOUNITS);
            public const string ONORDER = nameof(ONORDER);
            public const string COMMITTED = nameof(COMMITTED);
            public const string SOLD = nameof(SOLD);
            public const string RECEIVED = nameof(RECEIVED);
            public const string CONSTRUCT = nameof(CONSTRUCT);
            public const string BREAK_OUT = nameof(BREAK_OUT);
            public const string CARRIER = nameof(CARRIER);
            public const string POQUANT = nameof(POQUANT);
            public const string REORDQUANT = nameof(REORDQUANT);
            public const string REORDPRICE = nameof(REORDPRICE);
            public const string ASSOC = nameof(ASSOC);
            public const string DELDATE = nameof(DELDATE);
            public const string DELFLAG = nameof(DELFLAG);
            public const string DELUNITS = nameof(DELUNITS);
            public const string DELTOTAL = nameof(DELTOTAL);
            public const string BIN = nameof(BIN);
            public const string OVERSIZE = nameof(OVERSIZE);
            public const string NOTATION = nameof(NOTATION);
            public const string SHIPCHARGE = nameof(SHIPCHARGE);
            public const string CURSUPPLY = nameof(CURSUPPLY);
            public const string DISTRIB = nameof(DISTRIB);
            public const string DISTSTOCK = nameof(DISTSTOCK);
            public const string OWN_BOX = nameof(OWN_BOX);
            public const string TAX_CLASS = nameof(TAX_CLASS);
            public const string UPCCODE = nameof(UPCCODE);
            public const string SERIAL = nameof(SERIAL);
            public const string NEXTSER = nameof(NEXTSER);
            public const string DISCONT = nameof(DISCONT);
            public const string COMMGROSS = nameof(COMMGROSS);
            public const string COMMNET = nameof(COMMNET);
            public const string COMMFLAT = nameof(COMMFLAT);
            public const string SUBSPROD = nameof(SUBSPROD);
            public const string PUBLCTNCD = nameof(PUBLCTNCD);
            public const string SUBSISUCT = nameof(SUBSISUCT);
            public const string PRODXINVC = nameof(PRODXINVC);
            public const string ROYALTY = nameof(ROYALTY);
            public const string DISCONTINU = nameof(DISCONTINU);
            public const string OTHER1 = nameof(OTHER1);
            public const string OTHER2 = nameof(OTHER2);
            public const string SERIALSKU = nameof(SERIALSKU);
            public const string UNITSINBOX = nameof(UNITSINBOX);
            public const string LPURCHDATE = nameof(LPURCHDATE);
            public const string LPURCHQTY = nameof(LPURCHQTY);
            public const string SIZE_COLOR = nameof(SIZE_COLOR);
            public const string FRACTIONS = nameof(FRACTIONS);
            public const string INETSELL = nameof(INETSELL);
            public const string INETDESC = nameof(INETDESC);
            public const string INETDEP = nameof(INETDEP);
            public const string INETSUBDEP = nameof(INETSUBDEP);
            public const string INETCSMSG = nameof(INETCSMSG);
            public const string INETCSPROD = nameof(INETCSPROD);
            public const string INETIMAGE = nameof(INETIMAGE);
            public const string CANTSELL = nameof(CANTSELL);
            public const string SALES_DEPT = nameof(SALES_DEPT);
            public const string ROYSUP = nameof(ROYSUP);
            public const string ROYNET = nameof(ROYNET);
            public const string ROYGROSS = nameof(ROYGROSS);
            public const string ROYFLAT = nameof(ROYFLAT);
            public const string INETCUSTOM = nameof(INETCUSTOM);
            public const string INETCPRPMT = nameof(INETCPRPMT);
            public const string DROPMETHOD = nameof(DROPMETHOD);
            public const string INETCPRMPT = nameof(INETCPRMPT);
            public const string INETCPRICE = nameof(INETCPRICE);
            public const string INETUSPROD = nameof(INETUSPROD);
            public const string INETUSMSG = nameof(INETUSMSG);
            public const string INETTHUMB = nameof(INETTHUMB);
            public const string SENDNOTICE = nameof(SENDNOTICE);
            public const string NOTICEWHEN = nameof(NOTICEWHEN);
            public const string GIFTCERT = nameof(GIFTCERT);
            public const string POINTS_REV = nameof(POINTS_REV);
            public const string POINTS_NED = nameof(POINTS_NED);
            public const string KIT_MAKE = nameof(KIT_MAKE);
            public const string KIT_BREAK = nameof(KIT_BREAK);
            public const string ISBN = nameof(ISBN);
            public const string RTNS_DEPT = nameof(RTNS_DEPT);
            public const string COGS_DEPT = nameof(COGS_DEPT);
            public const string SUBSTITUTE = nameof(SUBSTITUTE);
            public const string WAREPREF = nameof(WAREPREF);
            public const string WARE_ALTOK = nameof(WARE_ALTOK);
            public const string SINGLEBIN = nameof(SINGLEBIN);
            public const string RCOMMIT = nameof(RCOMMIT);
            public const string CANBUYITEM = nameof(CANBUYITEM);
            public const string DONORDER = nameof(DONORDER);
            public const string DBOUNITS = nameof(DBOUNITS);
            public const string NEEDCUSTOM = nameof(NEEDCUSTOM);
            public const string CUSTOMTEXT = nameof(CUSTOMTEXT);
            public const string PREFSHIP = nameof(PREFSHIP);
            public const string ADVANCED1 = nameof(ADVANCED1);
            public const string ADVANCED2 = nameof(ADVANCED2);
            public const string ADVANCED3 = nameof(ADVANCED3);
            public const string ADVANCED4 = nameof(ADVANCED4);
            public const string PICTURE = nameof(PICTURE);
            public const string CLUBPROD = nameof(CLUBPROD);
            public const string CLUB_CODE = nameof(CLUB_CODE);
            public const string AUCTSELL = nameof(AUCTSELL);
            public const string AUCTUNIT = nameof(AUCTUNIT);
            public const string STOCK_ID = nameof(STOCK_ID);
            public const string BO_AHEAD = nameof(BO_AHEAD);
            public const string HIDE_ITEM = nameof(HIDE_ITEM);
            public const string MAXDSCT = nameof(MAXDSCT);
            public const string MIN_MKUP_D = nameof(MIN_MKUP_D);
            public const string MIN_MKUP_P = nameof(MIN_MKUP_P);
            public const string MIN_PRICE = nameof(MIN_PRICE);
            public const string NORETURN = nameof(NORETURN);
            public const string PRINTSTKID = nameof(PRINTSTKID);
            public const string SHIPEXEMPT = nameof(SHIPEXEMPT);
            public const string SL_IMAGE1 = nameof(SL_IMAGE1);
            public const string SL_IMAGE2 = nameof(SL_IMAGE2);
            public const string SL_IMAGE3 = nameof(SL_IMAGE3);
            public const string SL_IMAGE4 = nameof(SL_IMAGE4);
            public const string SL_IMAGE5 = nameof(SL_IMAGE5);
            public const string SL_IMAGE6 = nameof(SL_IMAGE6);
            public const string SL_IMAGE7 = nameof(SL_IMAGE7);
            public const string SL_IMAGE8 = nameof(SL_IMAGE8);
            public const string THRESHTYPE = nameof(THRESHTYPE);
            public const string NUM_BOXES = nameof(NUM_BOXES);
            public const string PMMPROD = nameof(PMMPROD);
            public const string PMMTEXT = nameof(PMMTEXT);
            public const string ATTRIBS = nameof(ATTRIBS);
            public const string PMM_BREAK = nameof(PMM_BREAK);
            public const string PRODAVAIL = nameof(PRODAVAIL);
            public const string META_TITLE = nameof(META_TITLE);
            public const string NO_ORDER = nameof(NO_ORDER);
            public const string UOM = nameof(UOM);
            public const string PMM_MAKE = nameof(PMM_MAKE);
            public const string PMUNITS = nameof(PMUNITS);
            public const string CONDITION = nameof(CONDITION);
            public const string MANUFACTUR = nameof(MANUFACTUR);
            public const string GIFTCARD = nameof(GIFTCARD);
            public const string HAZORDOUS = nameof(HAZORDOUS);
            public const string HANDLING = nameof(HANDLING);
            public const string PRODURL = nameof(PRODURL);
            public const string DRYICE = nameof(DRYICE);
            public const string DRYICEWGHT = nameof(DRYICEWGHT);
            public const string FBAUNITS = nameof(FBAUNITS);
            public const string COMMODITY = nameof(COMMODITY);
            public const string ALCOHOL = nameof(ALCOHOL);
            public const string LITHUIUM = nameof(LITHUIUM);
            public const string DOWNLOADPRD = nameof(DOWNLOADPRD);

            // orders

            public const string CL_KEY = nameof(CL_KEY);
            public const string HOLD_TYPE = nameof(HOLD_TYPE);
            public const string PERM_HOLD = nameof(PERM_HOLD);
            public const string SYS_HOLD = nameof(SYS_HOLD);
            public const string HOLD_DATE = nameof(HOLD_DATE);
            public const string REL_DATE = nameof(REL_DATE);
            public const string CLEAR_DATE = nameof(CLEAR_DATE);
            public const string SHIP_DATE = nameof(SHIP_DATE);
            public const string CHECK = nameof(CHECK);
            public const string APPROVAL = nameof(APPROVAL);
            public const string CCCORR = nameof(CCCORR);
            public const string TAX = nameof(TAX);
            public const string SHIPPING = nameof(SHIPPING);
            public const string OTHERCOST = nameof(OTHERCOST);
            public const string CHECKAMOUN = nameof(CHECKAMOUN);
            public const string ORD_TOTAL = nameof(ORD_TOTAL);
            public const string CHARGED = nameof(CHARGED);
            public const string CORRECTIN = nameof(CORRECTIN);
            public const string CORRECTLC = nameof(CORRECTLC);
            public const string INVOICED = nameof(INVOICED);
            public const string LASTINV = nameof(LASTINV);
            public const string VCOUNT = nameof(VCOUNT);
            public const string LABELED = nameof(LABELED);
            public const string LABELS = nameof(LABELS);
            public const string DLABELS = nameof(DLABELS);
            public const string COMPLETED = nameof(COMPLETED);
            public const string CAN_ORD = nameof(CAN_ORD);
            public const string MULTISHIP = nameof(MULTISHIP);
            public const string NINV = nameof(NINV);
            public const string NFILL = nameof(NFILL);
            public const string NPACK = nameof(NPACK);
            public const string NSHIP = nameof(NSHIP);
            public const string NBOR = nameof(NBOR);
            public const string VBOR = nameof(VBOR);
            public const string VDSB = nameof(VDSB);
            public const string VITEMHOLDS = nameof(VITEMHOLDS);
            public const string NALL = nameof(NALL);
            public const string NITEMHOLDS = nameof(NITEMHOLDS);
            public const string EXTRA = nameof(EXTRA);
            public const string SHIPNUM = nameof(SHIPNUM);
            public const string DORD = nameof(DORD);
            public const string DBOR = nameof(DBOR);
            public const string DFILL = nameof(DFILL);
            public const string DPACK = nameof(DPACK);
            public const string DSHIP = nameof(DSHIP);
            public const string DALL = nameof(DALL);
            public const string PROCSSD = nameof(PROCSSD);
            public const string USERID = nameof(USERID);
            public const string LAST_USER = nameof(LAST_USER);
            public const string EXTRA2 = nameof(EXTRA2);
            public const string CHECKNUM = nameof(CHECKNUM);
            public const string PREVORD = nameof(PREVORD);
            public const string ZONE = nameof(ZONE);
            public const string C_TABLE = nameof(C_TABLE);
            public const string VNTM = nameof(VNTM);
            public const string SHIPTYPE = nameof(SHIPTYPE);
            public const string TB_MERCH = nameof(TB_MERCH);
            public const string TB_SHIP = nameof(TB_SHIP);
            public const string NOTYETUSED = nameof(NOTYETUSED);
            public const string TB_TAX = nameof(TB_TAX);
            public const string TB_NONTAX = nameof(TB_NONTAX);
            public const string SHIPMODIFY = nameof(SHIPMODIFY);
            public const string NEEDWEIGHT = nameof(NEEDWEIGHT);
            public const string ORDER_ST2 = nameof(ORDER_ST2);
            public const string TELE_CODE = nameof(TELE_CODE);
            public const string TELEDONE = nameof(TELEDONE);
            public const string OVERPAY = nameof(OVERPAY);
            public const string ACC_STATE = nameof(ACC_STATE);
            public const string NEXT_PAY = nameof(NEXT_PAY);
            public const string TB_FINCHAR = nameof(TB_FINCHAR);
            public const string ALT_ORDER = nameof(ALT_ORDER);
            public const string NTAXSHIP = nameof(NTAXSHIP);
            public const string INTERNETID = nameof(INTERNETID);
            public const string CARDINLIST = nameof(CARDINLIST);
            public const string HOLDNOTE = nameof(HOLDNOTE);
            public const string SOLDNUM = nameof(SOLDNUM);
            public const string MULTIPAY = nameof(MULTIPAY);
            public const string CC_CID = nameof(CC_CID);
            public const string POINTS_USD = nameof(POINTS_USD);
            public const string ORDERTYPE = nameof(ORDERTYPE);
            public const string CARDHOLDER = nameof(CARDHOLDER);
            public const string NEED_GC = nameof(NEED_GC);
            public const string R_MERCH = nameof(R_MERCH);
            public const string R_TAX = nameof(R_TAX);
            public const string NR_MERCH = nameof(NR_MERCH);
            public const string NR_TAX = nameof(NR_TAX);
            public const string P_MERCH = nameof(P_MERCH);
            public const string P_TAX = nameof(P_TAX);
            public const string P_SHIP = nameof(P_SHIP);
            public const string TPSHIPTYPE = nameof(TPSHIPTYPE);
            public const string TPSHIPWHAT = nameof(TPSHIPWHAT);
            public const string TPSHIPACCT = nameof(TPSHIPACCT);
            public const string TPSHIPCC = nameof(TPSHIPCC);
            public const string TPSHIPEXP = nameof(TPSHIPEXP);
            public const string ENTRYTIME = nameof(ENTRYTIME);
            public const string FREIGHTCOL = nameof(FREIGHTCOL);
            public const string INTERNET = nameof(INTERNET);
            public const string PROCSSBY = nameof(PROCSSBY);
            public const string CCINQ_REQ =nameof(CCINQ_REQ);
            public const string REMOVECC = nameof(REMOVECC);
            public const string ORD_DISCT = nameof(ORD_DISCT);
            public const string PRIORITY = nameof(PRIORITY);
            public const string ISSUE_NUM = nameof(ISSUE_NUM);
            public const string FRDATE = nameof(FRDATE);
            public const string ORDPROMO = nameof(ORDPROMO);
            public const string CHARGE_ALL = nameof(CHARGE_ALL);
            public const string NO_PROMO = nameof(NO_PROMO);
            public const string ROUTINGNUM = nameof(ROUTINGNUM);
            public const string ACCOUNTNUM = nameof(ACCOUNTNUM);
            public const string ACCTTYPE = nameof(ACCTTYPE);
            public const string BANKNAME = nameof(BANKNAME);
            public const string PAYPALID = nameof(PAYPALID);
            public const string PINENTRY = nameof(PINENTRY);
            public const string ENCTYPE = nameof(ENCTYPE);
            public const string BADLABEL = nameof(BADLABEL);
            public const string DUE_ONDATE = nameof(DUE_ONDATE);
            public const string HOLDCODE = nameof(HOLDCODE);
            public const string ORDERSET = nameof(ORDERSET);
            public const string URL_ID = nameof(URL_ID);

            // supplier

            public const string CODE = nameof(CODE);
            public const string L1 = nameof(L1);
            public const string L2 = nameof(L2);
            public const string L3 = nameof(L3);
            public const string FAX = nameof(FAX);
            public const string ACCOUNT = nameof(ACCOUNT);
            public const string SU_DROP = nameof(SU_DROP);
            public const string CONTACT = nameof(CONTACT);
            public const string TERMS = nameof(TERMS);
            public const string INSTRUCT1 = nameof(INSTRUCT1);
            public const string INSTRUCT2 = nameof(INSTRUCT2);
            public const string INSTRUCT3 = nameof(INSTRUCT3);
            public const string NOTE1 = nameof(NOTE1);
            public const string NOTE2 = nameof(NOTE2);
            public const string NOTE3 = nameof(NOTE3);
            public const string TERM_ALLOW = nameof(TERM_ALLOW);
            public const string PRINTPO = nameof(PRINTPO);
            public const string EMAILPO = nameof(EMAILPO);
            public const string FAXPO = nameof(FAXPO);
            public const string PTERMS = nameof(PTERMS);
            public const string LOADZONES = nameof(LOADZONES);
            public const string LEAD_AVG = nameof(LEAD_AVG);
            public const string MIN_UNITS = nameof(MIN_UNITS);
            public const string MIN_AMT = nameof(MIN_AMT);
            public const string MIN_REQ = nameof(MIN_REQ);
            public const string SHIPVIA = nameof(SHIPVIA);
            public const string SUPPLIER_ID = nameof(SUPPLIER_ID);
            public const string INACTIVE = nameof(INACTIVE);
            public const string LADJVAL = nameof(LADJVAL);
            public const string LADJVOL = nameof(LADJVOL);
            public const string LADJWEIGHT = nameof(LADJWEIGHT);
            public const string LSHPVAL = nameof(LSHPVAL);
            public const string LSHPVOL = nameof(LSHPVOL);
            public const string LSHIPWEIGHT = nameof(LSHIPWEIGHT);
            public const string LTAXVAL = nameof(LTAXVAL);
            public const string LTAXVOL = nameof(LTAXVOL);
            public const string LTAXWEIGHT = nameof(LTAXWEIGHT);
            public const string MAXVOL = nameof(MAXVOL);
            public const string MAXWEIGHT = nameof(MAXWEIGHT);
            public const string MINVOL = nameof(MINVOL);
            public const string MINWEIGHT = nameof(MINWEIGHT);
            public const string PHONEEXT = nameof(PHONEEXT);
            public const string EDI = nameof(EDI);

            // customer relationship

            public const string RELA_TYPE = nameof(RELA_TYPE);
            public const string CUSTRELA_ID = nameof(CUSTRELA_ID);

            // warehouse

            public const string UPSCA_ID = nameof(UPSCA_ID);
            public const string RETAIL = nameof(RETAIL);
            public const string MSG1 = nameof(MSG1);
            public const string MSG2 = nameof(MSG2);
            public const string WAREHOUS_ID = nameof(WAREHOUS_ID);
            public const string IS_PICKUP = nameof(IS_PICKUP);
            public const string ADDR_ID = nameof(ADDR_ID);
            public const string SH_UPS_ID = nameof(SH_UPS_ID);
            public const string SH_FEX_ID = nameof(SH_FEX_ID);
            public const string SH_USP_ID = nameof(SH_USP_ID);

            // state/provinces

            public const string HIGH = nameof(HIGH);
            public const string TAXRATE = nameof(TAXRATE);
            public const string FIN_RATE = nameof(FIN_RATE);
            public const string S_LCAPA = nameof(S_LCAPA);
            public const string S_LCAPB = nameof(S_LCAPB);
            public const string S_LCAPC = nameof(S_LCAPC);
            public const string S_LCAPD = nameof(S_LCAPD);
            public const string S_LCAPE = nameof(S_LCAPE);
            public const string S_LTAXITA = nameof(S_LTAXITA);
            public const string S_LTAXITB = nameof(S_LTAXITB);
            public const string S_LTAXITC = nameof(S_LTAXITC);
            public const string S_LTAXITD = nameof(S_LTAXITD);
            public const string S_LTAXITE = nameof(S_LTAXITE);
            public const string S_NCAPA = nameof(S_NCAPA);
            public const string S_NCAPB = nameof(S_NCAPB);
            public const string S_NCAPC = nameof(S_NCAPC);
            public const string S_NCAPD = nameof(S_NCAPD);
            public const string S_NCAPE = nameof(S_NCAPE);
            public const string S_NTAXITA = nameof(S_NTAXITA);
            public const string S_NTAXITB = nameof(S_NTAXITB);
            public const string S_NTAXITC = nameof(S_NTAXITC);
            public const string S_NTAXITD = nameof(S_NTAXITD);
            public const string S_NTAXITE = nameof(S_NTAXITE);
            public const string STAXTHRESA = nameof(STAXTHRESA);
            public const string STAXTHRESB = nameof(STAXTHRESB);
            public const string STAXTHRESC = nameof(STAXTHRESC);
            public const string STAXTHRESD = nameof(STAXTHRESD);
            public const string STAXTHRESE = nameof(STAXTHRESE);
            public const string TAXUPDATE = nameof(TAXUPDATE);
            public const string STATE_ID = nameof(STATE_ID);

            // postal codes

            public const string ZIP_ID = nameof(ZIP_ID);
            public const string TYPE = nameof(TYPE);
            public const string RTDTAX = nameof(RTDTAX);
            public const string ITAXR = nameof(ITAXR);
            public const string LOGIC1 = nameof(LOGIC1);
            public const string I_LCAPA = nameof(I_LCAPA);
            public const string I_LCAPB = nameof(I_LCAPB);
            public const string I_LCAPC = nameof(I_LCAPC);
            public const string I_LCAPD = nameof(I_LCAPD);
            public const string I_LCAPE = nameof(I_LCAPE);
            public const string I_LTAXITA = nameof(I_LTAXITA);
            public const string I_LTAXITB = nameof(I_LTAXITB);
            public const string I_LTAXITC = nameof(I_LTAXITC);
            public const string I_LTAXITD = nameof(I_LTAXITD);
            public const string I_LTAXITE = nameof(I_LTAXITE);
            public const string I_NCAPA = nameof(I_NCAPA);
            public const string I_NCAPB = nameof(I_NCAPB);
            public const string I_NCAPC = nameof(I_NCAPC);
            public const string I_NCAPD = nameof(I_NCAPD);
            public const string I_NCAPE = nameof(I_NCAPE);
            public const string I_NTAXITA = nameof(I_NTAXITA);
            public const string I_NTAXITB = nameof(I_NTAXITB);
            public const string I_NTAXITC = nameof(I_NTAXITC);
            public const string I_NTAXITD = nameof(I_NTAXITD);
            public const string I_NTAXITE = nameof(I_NTAXITE);
            public const string ITAXTHRESA = nameof(ITAXTHRESA);
            public const string ITAXTHRESB = nameof(ITAXTHRESB);
            public const string ITAXTHRESC = nameof(ITAXTHRESC);
            public const string ITAXTHRESD = nameof(ITAXTHRESD);
            public const string ITAXTHRESE = nameof(ITAXTHRESE);

        }
    }
}

