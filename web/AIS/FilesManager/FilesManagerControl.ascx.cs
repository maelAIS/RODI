﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AIS_FilesManager_FilesManagerControl : System.Web.UI.UserControl
{
    /// <summary>
    /// Indiquer le chemin relatif du repertoire
    /// </summary>
    string pathFile = "";
    public string PathFile
    {
        get
        {
            return pathFile;
        }

        set
        {
            pathFile = value;
            hfd_path.Value = pathFile;
        }
    }

    /// <summary>
    /// Permet ou pas de sélectionner plusieurs fichiers à uploader
    /// </summary>
    bool multipleFiles = false;
    public bool Multiple
    {
        get
        {
            return multipleFiles;
        }

        set
        {
            multipleFiles = value;
            if (multipleFiles == true)
            { hfd_mult.Value = "multiple"; }
            else { hfd_mult.Value = ""; }
        }
    }

    /// <summary>
    /// Permet d'avoir un thumb sur les images
    /// </summary>
    bool thumbImage = false;
    public bool ThumbImage
    {
        get
        {
            return thumbImage;
        }

        set
        {
            thumbImage = value;
            hfd_thumb.Value = thumbImage.ToString().ToLower();
        }
    }

    /// <summary>
    /// A séparer par une vigule et sans espace
    /// </summary>
    string typeFilter = "";
    public string TypeFilter
    {
        get
        {
            return typeFilter;
        }

        set
        {
            typeFilter = value;
            hfd_typeFilter.Value = typeFilter;
        }
    }

    /// <summary>
    /// A séparer par une vigule et sans espace
    /// </summary>
    string extFilter = "";
    public string ExtFilter
    {
        get
        {
            return extFilter;
        }

        set
        {
            extFilter = value;
            hfd_extFilter.Value = extFilter;
        }
    }

    /// <summary>
    /// Example : audio/*,video/*,image/*, .gif, .jpg, .png, .doc
    /// </summary>
    string extAuthorised = "";
    public string ExtAuthorised
    {
        get
        {
            return extAuthorised;
        }

        set
        {
            extAuthorised = value;
            hfd_extAuthorised.Value = extAuthorised;
        }
    }

    /// <summary>
    /// Permet de n'avoir que le visu d'un répertoire
    /// </summary>
    bool readOnly = false;
    public bool ReadOnly
    {
        get
        {
            return readOnly;
        }

        set
        {
            readOnly = value;
            hfd_readOnly.Value = readOnly.ToString().ToLower();
        }
    }

    /// <summary>
    /// Permet de n'avoir que le visu d'un répertoire
    /// </summary>
    bool nameHide = false;
    public bool NameHide
    {
        get
        {
            return nameHide;
        }

        set
        {
            nameHide = value;
            hfd_nameHide.Value = nameHide.ToString().ToLower();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}