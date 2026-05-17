namespace PcManager.DTOs;

// GET /api/pcs
public class PcListDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public float Weight { get; set; }
    public int Warranty { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Stock { get; set; }
}

// GET /api/pcs/{id}/components
public class PcWithComponentsDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public float Weight { get; set; }
    public int Warranty { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Stock { get; set; }
    public List<PcComponentDto> Components { get; set; } = new();
}

public class PcComponentDto
{
    public int Amount { get; set; }
    public ComponentDetailDto Component { get; set; } = null!;
}

public class ComponentDetailDto
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public ManufacturerDto Manufacturer { get; set; } = null!;
    public ComponentTypeDto Type { get; set; } = null!;
}

public class ManufacturerDto
{
    public int Id { get; set; }
    public string Abbreviation { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public DateOnly FoundationDate { get; set; }
}

public class ComponentTypeDto
{
    public int Id { get; set; }
    public string Abbreviation { get; set; } = null!;
    public string Name { get; set; } = null!;
}

// POST /api/pcs - request
public class CreatePcDto
{
    public string Name { get; set; } = null!;
    public float Weight { get; set; }
    public int Warranty { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Stock { get; set; }
}

// PUT /api/pcs/{id} - request
public class UpdatePcDto
{
    public string Name { get; set; } = null!;
    public float Weight { get; set; }
    public int Warranty { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Stock { get; set; }
}
