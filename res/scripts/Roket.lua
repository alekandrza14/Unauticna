-- defines a Jump function
function Jump (time)
	if (time>= 0.01) then
		return 1
	else
           	return 0
	end
end

function clamp(x,min,max)
	return x < min and min or x > max and max or x;
end


function Velosity (time,patrn)
local maxpatrn = 1;
patrn = math.fmod(patrn, maxpatrn);
	if (time>= 0.01 and patrn == 0) then
		vec3.y = 1;
		vec3.x = 0;
		vec3.z = 0;

		return vec3;

	end
end